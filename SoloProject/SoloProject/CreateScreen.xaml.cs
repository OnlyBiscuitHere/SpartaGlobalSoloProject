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
    /// Interaction logic for CreateScreen.xaml
    /// </summary>
    public partial class CreateScreen : Window
    {
        public CreateScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BlappyFirdLogic newAccount = new BlappyFirdLogic();
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var existing = newAccount.checkUser(username, password);
            if (existing)
                MessageBox.Show("This username or password has been used");
            else
            {
                newAccount.addUser(username, password, DateTime.Now);
                MessageBox.Show("Success account has been made");
                LoginScreen returnToLogin = new LoginScreen();
                returnToLogin.Show();
                this.Close();
            }
        }
    }
}
