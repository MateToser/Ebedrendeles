using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Ebedrendeles_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for ucOptions.xaml
    /// </summary>
    public partial class ucOptions : UserControl
    {
        public User USER;
        public ucOptions(User u)
        {
            InitializeComponent();
            USER = u;

            Betolt();
        }

        public void Betolt() //szemelyes adatok betoltese
        {
            try
            {
                Dictionary<string, string> data = Lib.getPersonalInfo(USER.userid);

                emailTextBox_s.Text = data["email"];
                usernameTextBox_s.Text = data["username"];
                passwordTextBox_s.Password = data["password"];
                passwordTextBox_s2.Password = data["password"];
                nameTextBox_s.Text = data["name"];
                addressTextBox_s.Text = data["address"];
            }
            catch (Exception) { }
        }

        private void optionSaveButton_Click(object sender, RoutedEventArgs e) //modositasok mentese
        {
            if (MessageBox.Show("Biztosan elmenti a módosításokat?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            if (passwordTextBox_s.Password.Length < 5)
            {
                MessageBox.Show("Min. 5 karakter hosszú legyen a jelszó!");
                passwordTextBox_s.Focus();
            }
            else if (passwordTextBox_s.Password != passwordTextBox_s2.Password)
            {
                MessageBox.Show("A két jelszó nem egyezik!");
                passwordTextBox_s2.Focus();
            }
            else if (nameTextBox_s.Text.Length < 5)
            {
                MessageBox.Show("Adja meg a nevét!");
                nameTextBox_s.Focus();
            }
            else if (!Regex.IsMatch(nameTextBox_s.Text, @"^[a-zA-Z]{1,20} [a-zA-Z]{1,20}"))
            {
                MessageBox.Show("Helytelen név!");
                nameTextBox_s.Focus();
            }
            else if (addressTextBox_s.Text.Length < 5)
            {
                MessageBox.Show("Adja meg a címét!");
                addressTextBox_s.Focus();
            }
            else if (!Regex.IsMatch(addressTextBox_s.Text, @"^[0-9]{1,4} [a-zA-Z]{1,20} [a-zA-Z\\s]{1,20}"))
            {
                MessageBox.Show("Helytelen cím!");
                addressTextBox_s.Focus();
            }
            else
            {
                {
                    if (Lib.updatePersonalInfo(USER.userid, passwordTextBox_s.Password, nameTextBox_s.Text, addressTextBox_s.Text))
                    {
                        MessageBox.Show("Sikeres adatmódosítás!");
                    }
                }
            }
        }
    }
}
