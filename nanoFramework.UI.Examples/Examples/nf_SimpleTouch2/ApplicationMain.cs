﻿using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;

namespace nf_SimpleTouch
{

    public class ApplicationMain : Application
    {
        static ApplicationMain myApplication;
        private WindowTouchButtons touchButtonWindow;

        public static void Start()
        {
            myApplication = new ApplicationMain();
            Touch.Initialize(myApplication);     // Turn on touch notifications
                                                 //       Window mainWindow = myApplication.CreateInkDrawingWindow();
            Window touchButtonWindow = myApplication.CreateTouchButtonsWindow();


            //     myApplication.Run(mainWindow);
            myApplication.Run(touchButtonWindow);
        }


        /// <summary>
        /// </summary>
        /// <summary>
        /// Main window class, based on the standard Window.
        /// </summary>
        //public class WindowInkDrawing : Window
        //{
        //    SolidColorBrush brush = new SolidColorBrush(Color.Black);
        //    Pen pen = new Pen(ColorUtility.ColorFromRGB(255, 0, 0));
        //    Pen pen2 = new Pen(ColorUtility.ColorFromRGB(0, 0, 255));
        //    Text text = new Text();
        //    Panel panel = new Panel();
        //    ListBox lb = new ListBox();

        //    /// <summary>
        //    /// The default constructor.
        //    /// </summary>
        //    public WindowInkDrawing()
        //    {
        //        this.Background = new SolidColorBrush(Color.ForestGreen);
        //        text.Font = GetFont(FontResources.small);
        //        text.TextContent = "    Click Anywhere   ";
        //        text.HorizontalAlignment = HorizontalAlignment.Center;
        //        text.VerticalAlignment = VerticalAlignment.Center;

        //        // Add the text control to the window.
        //        this.Child = panel;
        //        panel.Children.Add(text);
        //    }

        //    // Structure to hold a point.
        //    struct point
        //    {
        //        public ushort x;
        //        public ushort y;
        //    }

        //    // Create 1000 points.
        //    const int pointCount = 1000;
        //    point[] Points = new point[pointCount];
        //    int pointIndex = 0;

        //    int cx = 0;
        //    int cy = 0;
        //    int r = 6;
        //    bool drawCircle = false;

        //    /// <summary>
        //    /// Helper function to add points to the array and invalidate the 
        //    /// appropriate rectangle.
        //    /// </summary>
        //    /// <param name="x"></param>
        //    /// <param name="y"></param>
        //    void AddPoint(int x, int y)
        //    {
        //        Points[pointIndex].x = (ushort)x;
        //        Points[pointIndex].y = (ushort)y;
        //        pointIndex = (pointIndex + 1) % pointCount;

        //        if (pointIndex > 1)
        //        {
        //            int x0, y0, x1, y1, t;
        //            x0 = Points[pointIndex - 2].x;
        //            y0 = Points[pointIndex - 2].y;
        //            x1 = Points[pointIndex - 1].x;
        //            y1 = Points[pointIndex - 1].y;
        //            if (x1 < x0) { t = x0; x0 = x1; x1 = t; }
        //            if (y1 < y0) { t = y0; y0 = y1; y1 = t; }
        //            x1 = x1 - x0 + 1;
        //            y1 = y1 - y0 + 1;
        //            if (x1 > 0 && y1 > 0)
        //            {
        //                InvalidateRect(x0, y0, x1, y1);
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// Handles the touch down event.
        //    /// </summary>
        //    /// <param name="e"></param>
        //    protected override void OnTouchDown(TouchEventArgs e)
        //    {
        //        base.OnTouchDown(e);

        //        // Start at the beginning of the array and set the flag to draw 
        //        // a circle.
        //        pointIndex = 0;
        //        drawCircle = true;

        //        int x;
        //        int y;

        //        e.GetPosition((UIElement)this, out x, out y);

        //        cx = x;
        //        cy = y;

        //        // Add the first point to the array.
        //        AddPoint(x, y);

        //        r = 10;

        //        // Change the text to show touch down and location.
        //        text.TextContent = "TouchDown (" + x.ToString() + "," +
        //            y.ToString() + ")";

        //        // Clear the entire screen because we've erased the previous 
        //        // line (if any).
        //        Invalidate();

        //        e.Handled = true;
        //    }

        //    /// <summary>
        //    /// Handles the touch up event.
        //    /// </summary>
        //    /// <param name="e"></param>
        //    protected override void OnTouchUp(TouchEventArgs e)
        //    {
        //        base.OnTouchUp(e);

        //        // Set the flag to draw a circle.
        //        drawCircle = true;
        //        int x;
        //        int y;

        //        e.GetPosition((UIElement)this, out x, out y);

        //        cx = x;
        //        cy = y;

        //        // Add the last point to the array.
        //        AddPoint(x, y);

        //        r = 6;

        //        // Change the text to show touch up and location.
        //        text.TextContent = "TouchUp (" + x.ToString() + "," +
        //            y.ToString() + ")";

        //        InvalidateRect(cx - r, cy - r, 2 * r, 2 * r);
        //    }

        //    /// <summary>
        //    /// Handles the touch move event.
        //    /// </summary>
        //    /// <param name="e"></param>
        //    protected override void OnTouchMove(TouchEventArgs e)
        //    {
        //        base.OnTouchMove(e);

        //        int x = 0;
        //        int y = 0;

        //        e.GetPosition((UIElement)this, out x, out y);

        //        // Add this point to the array.
        //        AddPoint(x, y);

        //        text.TextContent = "TouchMove (" + x.ToString() + "," + y.ToString() + ")";
        //    }

        //    /// <summary>
        //    /// Handles the render event.
        //    /// </summary>
        //    /// <param name="dc"></param>
        //    public override void OnRender(DrawingContext dc)
        //    {
        //        base.OnRender(dc);

        //        // If the flag is set, draw a circle.
        //        if (drawCircle)
        //        {
        //            dc.DrawEllipse(brush, pen, cx, cy, r, r);
        //        }

        //        // If we have some points, draw lines between them to make a 
        //        // complete path.
        //        if (pointIndex > 1)
        //        {
        //            for (int i = 1; i < pointIndex; i++)
        //            {
        //                dc.DrawLine(pen2, Points[i - 1].x, Points[i - 1].y,
        //                    Points[i].x, Points[i].y);
        //            }
        //        }
        //    }
        //}

        public class WindowTouchButtons : Window
        {
            Text text = new Text();
            public WindowTouchButtons()
            {
                StackPanel mainScreenStack = new StackPanel(Orientation.Vertical);
                Panel ClientPanel = new Panel();
                Panel NavigationPanel = new Panel();

                mainScreenStack.Children.Add(ClientPanel);
                mainScreenStack.Children.Add(NavigationPanel);

                int spaceBetweenButtons = 5;
                int numberOfButtons = 4;
                int touchButtonHeight = DisplayControl.ScreenHeight / numberOfButtons - (3 * spaceBetweenButtons);


                Canvas canvas = new Canvas();
                Font smallFont = Resources.GetFont(Resources.FontResources.small);
                TouchButton[] tb = new TouchButton[4];
                for (int i = 0; i < numberOfButtons; i++)
                {
                    tb[i] =  new TouchButton(smallFont, "Touch Button" + i.ToString());
                    tb[i].AddToCanvas(canvas,i* spaceBetweenButtons + i*touchButtonHeight, 10);
                    tb[i].PressedBackgroundColor = Color.Red;
                    tb[i].Click += Button_Click;
                }

                text.Font = Resources.GetFont(Resources.FontResources.small);
                text.TextContent = "   Waiting for a touch button ";
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;

                canvas.Children.Add(text);
                Canvas.SetTop(text, 150);
                Canvas.SetLeft(text, 250);

                this.Child = canvas;

            }

            private void Button_Click(object sender, EventArgs e)
            {
                TouchButton pressedButton = (TouchButton)sender;
                //                this.text = new Text(pressedButton.Text);
                this.text.TextContent = pressedButton.Text;
            }
        }

        /// <summary>
        /// Create a window with button focus.
        /// </summary>
        /// <returns></returns>
        //public Window CreateInkDrawingWindow()
        //{
        //    // Create a window object and set its size to the size of the 
        //    // display.
        //    mainWindow = new WindowInkDrawing();
        //    mainWindow.Height = DisplayControl.ScreenHeight;
        //    mainWindow.Width = DisplayControl.ScreenWidth;

        //    // Set the window visibility to Visible.
        //    mainWindow.Visibility = Visibility.Visible;

        //    // Attach the button focus to the window.
        //    Buttons.Focus(mainWindow);

        //    return mainWindow;
        //}
        public Window CreateTouchButtonsWindow()
        {
            // Create a window object and set its size to the size of the 
            // display.
            touchButtonWindow = new WindowTouchButtons();
            touchButtonWindow.Height = DisplayControl.ScreenHeight;
            touchButtonWindow.Width = DisplayControl.ScreenWidth;

            // Set the window visibility to Visible.
            touchButtonWindow.Visibility = Visibility.Visible;

            // Attach the button focus to the window.
            Buttons.Focus(touchButtonWindow);

            return touchButtonWindow;
        }

    }
}
