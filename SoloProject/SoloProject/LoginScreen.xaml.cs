using Microsoft.Data.SqlClient;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private BlappyFirdLogic _logic = new BlappyFirdLogic();
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var pass = _logic.checkUser(username, password);
            if (username == "user1" && password == "123")
            {
                AdminScreen admin = new AdminScreen();
                admin.Show();
                this.Close();
            }
            else if (pass == true)
            {
                var userid = _logic.returnUser(username);
                MainWindow dashboard = new MainWindow(userid, username);
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateScreen createScreen = new CreateScreen();
            createScreen.Show();
            this.Close();
        }
    }
}
