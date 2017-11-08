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
using Ebedrendeles_adatbazis;

namespace Ebedrendeles_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for ucLogin.xaml
    /// </summary>
    public partial class ucLogin : UserControl
    {
        public delegate void loginDelegate(string user, string pass, bool isAdmin);
        public loginDelegate lD;
        public User USER;
        public ucLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (USER.isLoggedIn())
                return;

            if (Lib.tryLogin(userTextBox_l.Text, passwordTextBox_l.Password)) //belepesi adatok lekerese
            {
                MessageBox.Show("Sikeres belépés!");
                lD(userTextBox_l.Text, passwordTextBox_l.Password, userTextBox_l.Text.ToLower().Equals("admin") ? true : false);
            }
            else
            {
                MessageBox.Show("Sikertelen belépés!");
            }
        }
    }
}
