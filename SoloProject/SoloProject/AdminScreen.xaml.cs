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
using BlappyFird;

namespace SoloProject
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        private BlappyFirdLogic _logic = new BlappyFirdLogic();
        public AdminScreen()
        {
            InitializeComponent();
        }

        private void ListBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxUsers.ItemsSource = _logic.printAllUsers();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_logic.selectedUser != null)
            {
                txtId.Text = _logic.selectedUser.UsersId.ToString();
                txtUsername.Text = _logic.selectedUser.Username;
                txtPassword.Text = _logic.selectedUser.Password;
                txtCreated.Text = _logic.selectedUser.Created.ToString();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_logic.selectedUser != null)
            {
                bool deleted = _logic.deleteUser(_logic.selectedUser.UsersId);
                if (deleted)
                {
                    MessageBox.Show("User has been deleted");
                }
                else
                    MessageBox.Show("User could not be found");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen returnToLogin = new LoginScreen();
            returnToLogin.Show();
            this.Close();
        }
    }
}
