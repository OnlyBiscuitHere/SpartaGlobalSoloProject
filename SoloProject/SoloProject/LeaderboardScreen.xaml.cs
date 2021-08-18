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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BlappyFird;

namespace SoloProject
{
    /// <summary>
    /// Interaction logic for LeaderboardScreen.xaml
    /// </summary>
    public partial class LeaderboardScreen : Window
    {
        private BlappyFirdLogic _logic = new BlappyFirdLogic();
        public LeaderboardScreen()
        {
            InitializeComponent();
            var list = BlappyFirdLogic.GetLeaderboard();
            Leaderboard.ItemsSource = list;
        }

    }
}
