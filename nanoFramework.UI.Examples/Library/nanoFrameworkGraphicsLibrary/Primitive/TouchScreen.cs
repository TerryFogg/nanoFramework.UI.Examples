//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class TouchScreen : IEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        public class ActiveRectangle
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="width"></param>
            /// <param name="height"></param>
            /// <param name="target"></param>
            public ActiveRectangle(int x, int y, int width, int height, object target)
            {
                this.X = x;
                this.Y = y;
                this.Width = width;
                this.Height = height;
                this.Target = target;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public bool Contains(TouchCoordinate input)
            {
                if (
                    input.X >= this.X &&
                    input.X < this.X + this.Width &&
                    input.Y >= this.Y &&
                    input.Y < this.Y + this.Height
                  )
                {
                    return true;
                }
                return false;
            }

            //--//

            /// <summary>
            /// 
            /// </summary>
            public readonly int X;

            /// <summary>
            /// 
            /// </summary>
            public readonly int Y;

            /// <summary>
            /// 
            /// </summary>
            public readonly int Width;

            /// <summary>
            /// 
            /// </summary>
            public readonly int Height;

            /// <summary>
            /// 
            /// </summary>
            public readonly object Target;
        }

        //--//

        private ActiveRectangle[] _activeRegions;
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        //--//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activeRectangles"></param>
        public TouchScreen(ActiveRectangle[] activeRectangles)
        {
            _maxWidth = DisplayControl.ScreenWidth;
            _maxHeight = DisplayControl.ScreenHeight;

            if (activeRectangles == null || activeRectangles.Length == 0)
            {
                this.ActiveRegions = new ActiveRectangle[] { new ActiveRectangle(0, 0, _maxWidth, _maxHeight, null) };
            }
            else
            {
                this.ActiveRegions = activeRectangles;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event TouchScreenEventHandler OnTouchDown;

        /// <summary>
        /// 
        /// </summary>
        public event TouchScreenEventHandler OnTouchMove;

        /// <summary>
        /// 
        /// </summary>
        public event TouchScreenEventHandler OnTouchUp;

        /// <summary>
        /// 
        /// </summary>
        public event TouchGestureEventHandler OnTouchGesture;

        /// <summary>
        /// 
        /// </summary>
        public ActiveRectangle[] ActiveRegions
        {
            set
            {
                // check
                for (int i = 0; i < value.Length; ++i)
                {
                    ActiveRectangle ar = value[i];
                    if (ar.X < 0 || ar.X >= _maxWidth || ar.Y < 0 || ar.Y >= _maxHeight)
                    {
                        throw new ArgumentException();
                    }
                }

                _activeRegions = value;
            }
            get
            {
                return _activeRegions;
            }
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        void IEventListener.InitializeForEventSource()
        {
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        bool IEventListener.OnEvent(BaseEvent ev)
        {
            // Process known events, otherwise forward as generic to MainWindow.
            //

            TouchEvent touchEvent = ev as TouchEvent;
            if (touchEvent != null)
            {
                // dispatch only when the event is in the active area            
                for (int i = 0; i < _activeRegions.Length; ++i)
                {
                    ActiveRectangle ar = _activeRegions[i];

                    // only check the first 
                    if (ar.Contains(touchEvent.Touches))
                    {
                        TouchScreenEventArgs tea = new TouchScreenEventArgs(touchEvent.Time, touchEvent.Touches, ar.Target);

                        switch ((TouchMessages)touchEvent.Message)
                        {
                            case TouchMessages.Down:
                                if (OnTouchDown != null)
                                {
                                    OnTouchDown(this, tea);
                                }
                                break;
                            case TouchMessages.Up:
                                if (OnTouchUp != null)
                                {
                                    OnTouchUp(this, tea);

                                    // Check for touch gesture at touch up

                                    TouchGestureVelocity velocity = TouchGestureVelocity.Medium; // Set to a default, to be implemented at a later date
                                    TouchGestureEventArgs gesture = new TouchGestureEventArgs(touchEvent.TouchGesture, velocity);

                                    if (touchEvent.TouchGesture != TouchGesture.NoGesture)
                                    {
                                        if (OnTouchGesture != null)
                                        {
                                            OnTouchGesture(this, gesture);
                                        }
                                    }

                                }
                                break;
                            case TouchMessages.Move:
                                if (OnTouchMove != null)
                                {
                                    OnTouchMove(this, tea);
                                }
                                break;
                        }
                    }
                }

                return true;
            }
            return false;
        }
    }
}


