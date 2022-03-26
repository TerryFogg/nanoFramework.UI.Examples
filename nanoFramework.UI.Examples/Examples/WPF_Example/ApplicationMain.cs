using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;

namespace WPF_Example
{
    public class ApplicationMain : Application
    {
        static ApplicationMain myApplication;
        private WindowTouchButtons touchButtonWindow;

        public static void Start()
        {
            myApplication = new ApplicationMain();
            Touch.Initialize(myApplication);     // Turn on touch notifications
            Window touchButtonWindow = myApplication.CreateTouchButtonsWindow();
            myApplication.Run(touchButtonWindow);
        }
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

                Canvas canvas = new Canvas();
                Font smallFont = Resource.GetFont(Resource.FontResources.small);
                TouchButton tb1 = new TouchButton(smallFont, "Touch Button 1");
                tb1.AddToCanvas(canvas, 5, 10);
                tb1.PressedBackgroundColor = Color.Red;
                tb1.Click += Button_Click;
                TouchButton tb2 = new TouchButton(smallFont, "Touch Button 2");
                tb2.AddToCanvas(canvas, 80, 10);
                tb2.PressedBackgroundColor = Color.Green;
                tb2.Click += Button_Click;
                TouchButton tb3 = new TouchButton(smallFont, "Touch Button 3");
                tb3.AddToCanvas(canvas, 155, 10);
                tb3.PressedBackgroundColor = Color.Yellow;
                tb3.Click += Button_Click;
                TouchButton tb4 = new TouchButton(smallFont, "Touch Button 4");
                tb4.AddToCanvas(canvas, 230, 10);
                tb4.PressedBackgroundColor = Color.Blue;
                tb4.Click += Button_Click;

                text.Font = Resource.GetFont(Resource.FontResources.small);
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
                this.text.TextContent = pressedButton.Text;
            }
        }
        public Window CreateTouchButtonsWindow()
        {
            // Create a window object and set its size to the size of the display.
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
