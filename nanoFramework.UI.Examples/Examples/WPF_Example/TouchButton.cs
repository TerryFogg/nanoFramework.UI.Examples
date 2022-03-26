using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;

namespace WPF_Example
{
    public class TouchButton : Border
    {
        private Text buttonText;

        public Color BorderColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color PressedBorderColor { get; set; }
        public Color PressedBackgroundColor { get; set; }

        public event EventHandler Click;

        private Canvas container;
        private int top;
        private int left;

        public TouchButton(Font font, string content)
            : this(font, content, null, 0, 0)
        {  }

        public TouchButton(Font font, string content, Canvas canvas, int top, int left)
        {
            BackgroundColor = Color.LightGray;
            BorderColor = Color.DarkGray;
            PressedBorderColor = Color.DarkGray;
            PressedBackgroundColor = Color.LightGray;

            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.Background = new SolidColorBrush(BackgroundColor);
            this.BorderBrush = new SolidColorBrush(BorderColor);
            this.SetBorderThickness(2, 2, 2, 2);
            buttonText = new Text(font, content);
            buttonText.SetMargin(25);
            buttonText.HorizontalAlignment = HorizontalAlignment.Center;
            this.Child = buttonText;

            if (canvas != null)
                this.AddToCanvas(canvas, top, left);
        }

        protected override void OnTouchDown(TouchEventArgs e)
        {
          //  TouchCapture.Capture(this, CaptureMode.Element);
            if (container != null)
                Canvas.SetTop(this, top + 1);

            this.Background = new SolidColorBrush(PressedBackgroundColor);
            this.BorderBrush = new SolidColorBrush(PressedBorderColor);
            base.OnTouchDown(e);
        }
        // Don't 
        protected override void OnTouchMove(TouchEventArgs e)
        {
            //int x;
            //int y;
            //e.GetPosition(this, out x, out y);
            //if( )
            //{

            //}

            base.OnTouchMove(e);
        }
        protected override void OnTouchUp(TouchEventArgs e)
        {

            string eventSource = e.Source.ToString();
            if (container != null)
                Canvas.SetTop(this, top - 1);

            this.Background = new SolidColorBrush(BackgroundColor);
            this.BorderBrush = new SolidColorBrush(BorderColor);
            base.OnTouchUp(e);
            OnClick();
        }
        protected override void OnTouchGesture(TouchEventArgs e)
        {
            //int x;
            //int y;
            //e.GetPosition(this, out x, out y);
            //if( )
            //{

            //}

            base.OnTouchGesture(e);
        }
        public void AddToCanvas(Canvas canvas, int top, int left)
        {
            this.container = canvas;
            this.top = top;
            this.left = left;

            canvas.Children.Add(this);
            Canvas.SetTop(this, top);
            Canvas.SetLeft(this, left);
        }

        public string Text
        {
            get { return buttonText.TextContent; }
            set { buttonText.TextContent = value; }
        }

        protected virtual void OnClick()
        {
            if (Click != null)
                Click(this, EventArgs.Empty);
        }
    }
}

