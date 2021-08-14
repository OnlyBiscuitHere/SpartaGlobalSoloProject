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
using BlappyFird;

namespace SoloProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BlappyFirdLogic _blappyFird;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
