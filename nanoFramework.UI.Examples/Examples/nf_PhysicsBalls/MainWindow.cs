using Avalonia;
using Avalonia.Rendering;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using nanoFramework.UI.Threading;
using System;

namespace nf_PhysicsBalls
{
    public class MainWindow : Window
    {
        private PhysicsCanvas PhysicsCanvas;
        private RenderLoop RenderLoop;

        private Button ClearButton;

        private static Color[] BallColors = new Color[]
        {
            Color.Blue,
            Color.Cyan,
            Color.Green,
            Color.GreenYellow,
            Color.YellowGreen,
            Color.Yellow,
            Color.Orange,
            Color.OrangeRed,
            Color.Red,
            Color.Purple
        };

        public MainWindow()
        {
            InitializeComponent();

            PhysicsCanvas = this.Find<PhysicsCanvas>("PhysicsCanvas");
            PointerPressed += MainWindow_PointerPressed;

            ClearButton = this.Find<Button>("Clear");
            ClearButton.Click += ClearButton_Click;

            RenderLoop = new RenderLoop();
            RenderLoop.Add(PhysicsCanvas);
        }

        private void MainWindow_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            var rng = new Random();
            var radius = rng.NextDouble() * 100;
            Point position = e.GetPosition(PhysicsCanvas);

            var ball = new Ball(
                new Vector(position.X, position.Y),
                radius,
                new Vector(rng.NextDouble() * 100 - 50, rng.NextDouble() * 100 - 50),
                BallColors[rng.Next(BallColors.Length)]
            );

            PhysicsCanvas.AddBall(ball);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PhysicsCanvas.Clear();
        }

        private void InitializeComponent()
        {
        }
    }
}
