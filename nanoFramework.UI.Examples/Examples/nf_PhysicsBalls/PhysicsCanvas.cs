using Avalonia;
using Avalonia.Rendering;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using System;
using System.Collections;

namespace nf_PhysicsBalls
{
    public class PhysicsCanvas : Canvas, IRenderLoopTask
    {
        private ArrayList Balls { get; set; } = new ArrayList();
        public bool NeedsUpdate { get; private set; } = true;
        private TimeSpan LastUpdated { get; set; }
        private static Vector Gravity = new Vector(0, 9.81);
        private const double timeFactor = 5;

        public void AddBall(Ball ball)
        {
            Balls.Add(ball);
            Invalidate();
        }

        public void Clear()
        {
            Balls.Clear();
        }

        public override void Render(DrawingContext context)
        {
            base.Invalidate();

            foreach (Ball ball in Balls)
            {
                context.DrawGeometry(new SolidColorBrush(ball.Color), null, ball);
            }
        }

        public void Render()
        {
            Invalidate();
        }

        public void Update(TimeSpan time)
        {
            double frameTimeSeconds = (LastUpdated == null ? 0 : (time - LastUpdated)?.TotalSeconds ?? 0) * timeFactor;
            LastUpdated = time;

            for (int i = 0; i < Balls.Count; ++i)
            {
                ((Ball)Balls[i]).Gravitate(frameTimeSeconds, Gravity);
                ((Ball)Balls[i]).Updated = ((Ball)Balls[i]).ImpactBounding(frameTimeSeconds, new Rect(Canvas.GetTop(this),Canvas.GetBottom(this)));

                for (int other = i + 1; other < Balls.Count; ++other)
                {
                    ((Ball)Balls[i]).Updated = ((Ball)Balls[i]).Impact(frameTimeSeconds, (Ball)Balls[other]) | ((Ball)Balls[i]).Updated;
                }

                if (!((Ball)Balls[i]).Updated)
                {
                    ((Ball)Balls[i]).Move(frameTimeSeconds);
                }

                ((Ball)Balls[i]).ApplyFriction(frameTimeSeconds);
            }
        }
    }
}
