using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;
using static nf_WpfDemoApplication.Controls;

namespace nf_WpfDemoApplication
{
    /// <summary>
    /// Demonstrates the Windows Presentation Foundation functionality in .NET 
    /// NanoFramework.
    /// </summary>
    public class MySimpleWPFApplication : Application
    {
        // Fields to hold the fonts used by this demo.   
        static public Font NinaBFont;
        static public Font SmallFont;
        static public Bitmap Leaf;

        // Declare the main window.
        static Window mainWindow;

        /// <summary>
        /// Sets focus on the main window.
        /// </summary>
        public void GoHome()
        {
            Buttons.Focus(MySimpleWPFApplication.mainWindow);
        }

        static int PinNumber(char port, byte pin)
        {
            if (port < 'A' || port > 'J')
                throw new ArgumentException();

            return ((port - 'A') * 16) + pin;
        }

        internal void Start()
        {
           
        }



        internal class PresentationWindow : Window
        {
            protected MySimpleWPFApplication _program;

            /// <summary>
            /// Constructs a PresentationWindow for the specified program.
            /// </summary>
            /// <param name="program"></param>
            protected PresentationWindow(MySimpleWPFApplication program)
            {
                _program = program;

                // Make the window visible and the size of the LCD
                this.Visibility = Visibility.Visible;
                this.Width = DisplayControl.ScreenWidth;
                this.Height = DisplayControl.ScreenHeight;
                Buttons.Focus(this); // Set focus to this window
            }

            /// <summary>
            /// Removes this window from the Window Manager.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnButtonDown(ButtonEventArgs e)
            {
                // Removes this window form the Window Manager.
                this.Close();

                // When any button is pressed, go back to the Home page.
                _program.GoHome();
            }
        }

        /// <summary>
        /// This is the main menu window; it shows the animated, sliding menu icons and 
        /// instructions to the user. It also handles button presses to move the menu 
        /// icons and handle selection of the menu items.
        /// </summary>
        internal sealed class MainMenuWindow : PresentationWindow
        {
            // This member keeps the menu item panel around.
            private MenuItemPanel m_MenuItemPanel;

            /// <summary>
            /// Constructs a MainMenuWindow for the specified program.
            /// </summary>
            /// <param name="program"></param>
            public MainMenuWindow(MySimpleWPFApplication program)
                : base(program)
            {
                // Create some colors for the text items.
                Color instructionTextColor = ColorUtility.ColorFromRGB(255, 255, 255);
                Color backgroundColor = ColorUtility.ColorFromRGB(0, 0, 0);
                Color upperBackgroundColor = ColorUtility.ColorFromRGB(69, 69, 69);
                Color unselectedItemColor = ColorUtility.ColorFromRGB(192, 192, 192);
                Color selectedItemColor = ColorUtility.ColorFromRGB(128, 128, 128);

                // The Main window contains a vertical StackPanel.
                StackPanel panel = new StackPanel(Orientation.Vertical);
                this.Child = panel;

                // The top child contains a horizontal StackPanel.
                m_MenuItemPanel = new MenuItemPanel(this.Width, this.Height);

                // The top child contains the menu items.  We pass in the small bitmap, 
                // large bitmap a description and then a large bitmap to use as a common 
                // sized bitmap for calculating the width and height of a MenuItem.
                MenuItem menuItem1 = new MenuItem(Resource.BitmapResources.Vertical_Stack_Panel_Icon_Small, Resource.BitmapResources.Vertical_Stack_Panel_Icon, "Vertical Stack Panel", Resource.BitmapResources.Canvas_Panel_Icon);
                MenuItem menuItem2 = new MenuItem(Resource.BitmapResources.Horizontal_Stack_Panel_Icon_Small, Resource.BitmapResources.Horizontal_Stack_Panel_Icon, "Horizontal Stack Panel", Resource.BitmapResources.Canvas_Panel_Icon);
                MenuItem menuItem3 = new MenuItem(Resource.BitmapResources.Canvas_Panel_Icon_Small, Resource.BitmapResources.Canvas_Panel_Icon, "Canvas Panel", Resource.BitmapResources.Canvas_Panel_Icon);
                MenuItem menuItem4 = new MenuItem(Resource.BitmapResources.Scrollable_Panel_Icon_Small, Resource.BitmapResources.Scrollable_Panel_Icon, "Scrollable Panel", Resource.BitmapResources.Canvas_Panel_Icon);
                MenuItem menuItem5 = new MenuItem(Resource.BitmapResources.Free_Drawing_Panel_Icon_Small, Resource.BitmapResources.Free_Drawing_Panel_Icon, "Free Drawing Panel", Resource.BitmapResources.Canvas_Panel_Icon);

                // Add each of the menu items to the menu item panel
                m_MenuItemPanel.AddMenuItem(menuItem1);
                m_MenuItemPanel.AddMenuItem(menuItem2);
                m_MenuItemPanel.AddMenuItem(menuItem3);
                m_MenuItemPanel.AddMenuItem(menuItem4);
                m_MenuItemPanel.AddMenuItem(menuItem5);

                // Add the menu item panel to the main window panel
                panel.Children.Add(m_MenuItemPanel);
            }

            /// <summary>
            /// Handles button click events.
            /// </summary>
            /// <param name="e">The button event arguments.</param>
            protected override void OnButtonDown(ButtonEventArgs e)
            {
                switch (e.Button)
                {
                    // If <Enter> button is pressed, go into the selected demo
                    case Button.VK_SELECT:
                        {
                            switch (m_MenuItemPanel.CurrentChild)
                            {
                                case 0:  // Vertical Stack Panel Demo
                                    new StackPanelDemo(_program, Orientation.Vertical);
                                    break;
                                case 1:  // Horizontal Stack Panel Demo
                                    new StackPanelDemo(_program, Orientation.Horizontal);
                                    break;
                                case 2:  // Canvas Panel Demo
                                    new CanvasPanelDemo(_program);
                                    break;
                                case 3:  // Scrollable Panel Demo
                                    new ScrollPanelDemo(_program);
                                    break;
                                case 4:  // Free Drawing Panel Demo
                                    new FreeDrawingDemo(_program);
                                    break;
                            }
                        }
                        break;

                    // If <Left> button is pressed, change the menu item left one.
                    case Button.VK_LEFT:
                        {
                            if (m_MenuItemPanel != null)
                                m_MenuItemPanel.CurrentChild--;
                        }
                        break;

                    // If <Right> button is pressed, change the menu item right one.
                    case Button.VK_RIGHT:
                        {
                            if (m_MenuItemPanel != null)
                                m_MenuItemPanel.CurrentChild++;
                        }
                        break;
                }

                // Don't call base implementation (base.OnButtonDown) or we'll go back 
                // Home.
            }
        }

    }
}
