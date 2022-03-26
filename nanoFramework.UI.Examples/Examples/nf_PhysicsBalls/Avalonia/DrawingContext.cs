using System;
using Avalonia.Platform;
using Avalonia.Utilities;

namespace Avalonia.Media
{
    public sealed class DrawingContext : IDisposable
    {
        private readonly bool _ownsImpl;
        private int _currentLevel;

        readonly struct TransformContainer
        {
            public readonly Matrix LocalTransform;
            public readonly Matrix ContainerTransform;

            public TransformContainer(Matrix localTransform, Matrix containerTransform)
            {
                LocalTransform = localTransform;
                ContainerTransform = containerTransform;
            }
        }

        public DrawingContext(IDrawingContextImpl impl)
        {
            PlatformImpl = impl;
            _ownsImpl = true;
        }
        
        public DrawingContext(IDrawingContextImpl impl, bool ownsImpl)
        {
            _ownsImpl = ownsImpl;
            PlatformImpl = impl;
        }

        public IDrawingContextImpl PlatformImpl { get; }

        private Matrix _currentTransform = Matrix.Identity;

        private Matrix _currentContainerTransform = Matrix.Identity;

        /// <summary>
        /// Gets the current transform of the drawing context.
        /// </summary>
        public Matrix CurrentTransform
        {
            get { return _currentTransform; }
            private set
            {
                _currentTransform = value;
                var transform = _currentTransform * _currentContainerTransform;
                PlatformImpl.Transform = transform;
            }
        }

        //HACK: This is a temporary hack that is used in the render loop 
        //to update TransformedBounds property
        [Obsolete("HACK for render loop, don't use")]
        public Matrix CurrentContainerTransform => _currentContainerTransform;

        /// <summary>
        /// Draws an image.
        /// </summary>
        /// <param name="source">The image.</param>
        /// <param name="rect">The rect in the output to draw to.</param>
        public void DrawImage(IImage source, Rect rect)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            DrawImage(source, new Rect(source.Size), rect);
        }

        /// <summary>
        /// Draws an image.
        /// </summary>
        /// <param name="source">The image.</param>
        /// <param name="sourceRect">The rect in the image to draw.</param>
        /// <param name="destRect">The rect in the output to draw to.</param>
        /// <param name="bitmapInterpolationMode">The bitmap interpolation mode.</param>
        public void DrawImage(IImage source, Rect sourceRect, Rect destRect, BitmapInterpolationMode bitmapInterpolationMode = default)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            source.Draw(this, sourceRect, destRect, bitmapInterpolationMode);
        }

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="pen">The stroke pen.</param>
        /// <param name="p1">The first point of the line.</param>
        /// <param name="p2">The second point of the line.</param>
        public void DrawLine(IPen pen, Point p1, Point p2)
        {
            if (PenIsVisible(pen))
            {
                PlatformImpl.DrawLine(pen, p1, p2);
            }
        }

        /// <summary>
        /// Draws a geometry.
        /// </summary>
        /// <param name="brush">The fill brush.</param>
        /// <param name="pen">The stroke pen.</param>
        /// <param name="geometry">The geometry.</param>
        public void DrawGeometry(IBrush? brush, IPen? pen, Geometry geometry)
        {
            if (geometry.PlatformImpl is not null)
                DrawGeometry(brush, pen, geometry.PlatformImpl);
        }

        /// <summary>
        /// Draws a geometry.
        /// </summary>
        /// <param name="brush">The fill brush.</param>
        /// <param name="pen">The stroke pen.</param>
        /// <param name="geometry">The geometry.</param>
        public void DrawGeometry(IBrush? brush, IPen? pen, IGeometryImpl geometry)
        {
            _ = geometry ?? throw new ArgumentNullException(nameof(geometry));

            if (brush != null || PenIsVisible(pen))
            {
                PlatformImpl.DrawGeometry(brush, pen, geometry);
            }
        }
        public readonly struct PushedState : IDisposable
        {
            private readonly int _level;
            private readonly DrawingContext _context;
            private readonly Matrix _matrix;
            private readonly PushedStateType _type;

            public enum PushedStateType
            {
                None,
                Matrix,
                Opacity,
                Clip,
                MatrixContainer,
                GeometryClip,
                OpacityMask,
            }

            public PushedState(DrawingContext context, PushedStateType type, Matrix matrix = default(Matrix))
            {
                if (context._states is null)
                    throw new ObjectDisposedException(nameof(DrawingContext));

                _context = context;
                _type = type;
                _matrix = matrix;
                _level = context._currentLevel += 1;
                context._states.Push(this);
            }

            public void Dispose()
            {
                if (_type == PushedStateType.None)
                    return;
                if (_context._currentLevel != _level)
                    throw new InvalidOperationException("Wrong Push/Pop state order");
                _context._currentLevel--;
                if (_type == PushedStateType.Matrix)
                    _context.CurrentTransform = _matrix;
                else if (_type == PushedStateType.Clip)
                    _context.PlatformImpl.PopClip();
                else if (_type == PushedStateType.Opacity)
                    _context.PlatformImpl.PopOpacity();
                else if (_type == PushedStateType.GeometryClip)
                    _context.PlatformImpl.PopGeometryClip();
                else if (_type == PushedStateType.OpacityMask)
                    _context.PlatformImpl.PopOpacityMask();
            }
        }


        /// <summary>
        /// Pushes an opacity value.
        /// </summary>
        /// <param name="opacity">The opacity.</param>
        /// <returns>A disposable used to undo the opacity.</returns>
        public PushedState PushOpacity(double opacity)
        //TODO: Eliminate platform-specific push opacity call
        {
            PlatformImpl.PushOpacity(opacity);
            return new PushedState(this, PushedState.PushedStateType.Opacity);
        }

        /// <summary>
        /// Pushes an opacity mask.
        /// </summary>
        /// <param name="mask">The opacity mask.</param>
        /// <param name="bounds">
        /// The size of the brush's target area. TODO: Are we sure this is needed?
        /// </param>
        /// <returns>A disposable to undo the opacity mask.</returns>
        public PushedState PushOpacityMask(IBrush mask, Rect bounds)
        {
            PlatformImpl.PushOpacityMask(mask, bounds);
            return new PushedState(this, PushedState.PushedStateType.OpacityMask);
        }

        /// <summary>
        /// Pushes a matrix post-transformation.
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <returns>A disposable used to undo the transformation.</returns>
        public PushedState PushPostTransform(Matrix matrix) => PushSetTransform(CurrentTransform * matrix);

        /// <summary>
        /// Pushes a matrix pre-transformation.
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <returns>A disposable used to undo the transformation.</returns>
        public PushedState PushPreTransform(Matrix matrix) => PushSetTransform(matrix * CurrentTransform);

        /// <summary>
        /// Sets the current matrix transformation.
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <returns>A disposable used to undo the transformation.</returns>
        public PushedState PushSetTransform(Matrix matrix)
        {
            var oldMatrix = CurrentTransform;
            CurrentTransform = matrix;

            return new PushedState(this, PushedState.PushedStateType.Matrix, oldMatrix);
        }

        /// <summary>
        /// Pushes a new transform context.
        /// </summary>
        /// <returns>A disposable used to undo the transformation.</returns>

        /// <summary>
        /// Disposes of any resources held by the <see cref="DrawingContext"/>.
        /// </summary>
        public void Dispose()
        {
        }

        private static bool PenIsVisible(IPen? pen)
        {
            return pen?.Brush != null && pen.Thickness > 0;
        }
    }
}
