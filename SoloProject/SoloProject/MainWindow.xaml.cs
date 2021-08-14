using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BlappyFird;

namespace SoloProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        //private BlappyFirdLogic _blappyFird;
        public double score;
        public int gravity = 8;
        public bool gameOver;
        
        Rect hitBox;
        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();

        }
        private void MainEventTimer(object sender, EventArgs e)
        {
            txtScore.Content = $"Score: {score}";
            hitBox = new Rect(Canvas.GetLeft(flappyBird), Canvas.GetTop(flappyBird), flappyBird.Width - 12, flappyBird.Height);
            Canvas.SetTop(flappyBird, Canvas.GetTop(flappyBird) + gravity);
            if (Canvas.GetTop(flappyBird) < -30 || Canvas.GetTop(flappyBird) + flappyBird.Height > 460)
            {
                EndGame();
            }
            foreach (var x in Game.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
                    if (Canvas.GetLeft(x) < -100)
                    {
                        Canvas.SetLeft(x, 800);
                        score += 5;
                    }
                }
                Rect pillarHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                if (hitBox.IntersectsWith(pillarHitBox))
                {
                    EndGame();
                }
                if ((string)x.Tag == "clouds")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 1);
                    if (Canvas.GetLeft(x) < -250)
                    {
                        Canvas.SetLeft(x, 590);
                        score += .5;
                    }

                }
            }
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                flappyBird.RenderTransform = new RotateTransform(-29, flappyBird.Width / 2, flappyBird.Height / 2);
                gravity = -8;
            }
            if (e.Key == Key.R && gameOver == true)
            {
                StartGame();
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2);
            gravity = 8;
        }
        private void StartGame()
        {
            Game.Focus();
            int temp = 300;
            score = 0;
            gameOver = false;
            Canvas.SetTop(flappyBird, 190);
            foreach (var x in Game.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1")
                    Canvas.SetLeft(x, 500);
                if ((string)x.Tag == "obs2")
                    Canvas.SetLeft(x, 800);
                if ((string)x.Tag == "obs3")
                    Canvas.SetLeft(x, 1100);
                if ((string)x.Tag == "clouds")
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }
            gameTimer.Start();
        }
        private void EndGame()
        {
            gameTimer.Stop();
            gameOver = true;
            txtScore.Content += "Game over! Press R to restart";
        }
    }
}
