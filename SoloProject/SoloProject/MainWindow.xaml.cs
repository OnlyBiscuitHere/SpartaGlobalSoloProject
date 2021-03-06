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
using System.Timers;
using BlappyFird;
using System.Media;

namespace SoloProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BlappyFirdLogic _logic = new BlappyFirdLogic();
        Timer gameTimer = new Timer();
        //private BlappyFirdLogic _blappyFird;
        MediaPlayer backing = new MediaPlayer();
        MediaPlayer death = new MediaPlayer();
        public double score;
        public int gravity = 8;
        public bool gameOver;
        private int id;
        private readonly string user = "";
        private int gameSpeed;
        Rect hitBox;

        public MainWindow(int userid, string username, int speed)
        {
            InitializeComponent();
            id = userid;
            user = username;
            gameSpeed = speed;
            gameTimer = new System.Timers.Timer(speed);
            gameTimer.Elapsed += MainEventTimer;
            gameTimer.AutoReset = true;
            gameTimer.Enabled = true;
            StartGame();
            backing.Open(new Uri("C:\\Users\\h8bmf\\source\\repos\\SpartaGlobalSoloProject\\SoloProject\\SoloProject\\sounds\\BackTrack.mp3", UriKind.RelativeOrAbsolute));
            backing.Position = TimeSpan.Zero;
            backing.Volume = 0.1;
            backing.Play();
        }
        private void MainEventTimer(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                txtScore.Content = $"Player: {user} Score: {score}"; 
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

                            score += .5;
                        }
                        Rect pillarHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        if (hitBox.IntersectsWith(pillarHitBox))
                        {
                            EndGame();
                        }
                    }
                    if ((string)x.Tag == "clouds")
                    {
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - 1);

                        if (Canvas.GetLeft(x) < -250)
                        {
                            Canvas.SetLeft(x, 550);

                            score += .5;
                        }

                    }
                }
            });
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                flappyBird.RenderTransform = new RotateTransform(-20, flappyBird.Width / 2, flappyBird.Height / 2);
                gravity = -8;
            }

            if (e.Key == Key.R && gameOver == true)
            {
                StartGame();
                backing.Play();
                ClearScreen();
            }
            if (e.Key == Key.Escape && gameOver == true)
            {
                LoginScreen back = new LoginScreen();
                back.Show();
                this.Close();
            }
            if (e.Key == Key.Y && gameOver == true)
            {
                string value = "increase";
                gameSpeed = _logic.getSpeed(id);
                _logic.updateSpeed(id, gameSpeed, value);
                MainWindow newGame = new MainWindow(id, user, gameSpeed);
                Application.Current.MainWindow = newGame;
                newGame.Show();
                this.Close();
            }
            if (e.Key == Key.N && gameOver == true)
            {
                string value = "decrease";
                gameSpeed = _logic.getSpeed(id);
                _logic.updateSpeed(id, gameSpeed, value);
                MainWindow newGame = new MainWindow(id, user, gameSpeed);
                Application.Current.MainWindow = newGame;
                newGame.Show();
                this.Close();
            }
            if (e.Key == Key.L && gameOver == true)
            {
                LeaderboardScreen leaderboard = new LeaderboardScreen();
                leaderboard.Show();
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
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }

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
            backing.Stop();
            death.Open(new Uri("C:\\Users\\h8bmf\\source\\repos\\SpartaGlobalSoloProject\\SoloProject\\SoloProject\\sounds\\DeathSound.mp3", UriKind.RelativeOrAbsolute));
            death.Volume = 0.1;
            death.Play();
            int newScore = Convert.ToInt32(score);
            _logic.updateScore(id, newScore);
            txtExtra3.Content = "Game Over!!! Press R to restart.";
            txtExtra1.Content = "Press L to view Leaderboard, Press ESC to Login Screen";
            txtExtra2.Content = "Y to increase difficulty, N to decrease difficulty";
        }
        private void ClearScreen()
        {
            txtExtra1.Content = "";
            txtExtra2.Content = "";
            txtExtra3.Content = "";
        }
    }
}
