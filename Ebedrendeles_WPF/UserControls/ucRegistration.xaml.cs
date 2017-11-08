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
    /// Interaction logic for ucRegistration.xaml
    /// </summary>
    public partial class ucRegistration : UserControl
    {
        public User USER;
        public delegate void registratedDelegate();
        public registratedDelegate rD;
        public ucRegistration()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e) //regisztracio, adatok helyessegenek ellenorzese
        {
            if(!Regex.IsMatch(emailTextBox_r.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Helytelen email cím!");
                emailTextBox_r.Focus();
            }
            else if (usernameTextBox_r.Text.Length < 5)
            {
                MessageBox.Show("Adja meg a felhasználó nevét!");
                usernameTextBox_r.Focus();
            }
            else if (!Regex.IsMatch(usernameTextBox_r.Text, @"^[a-zA-Z][a-zA-Z0-9\._\-]{0,22}?[a-zA-Z0-9]{0,2}$"))
            {
                MessageBox.Show("Helytelen felhasználónév cím!");
                emailTextBox_r.Focus();
            }
            else if (passwordTextBox_r.Password.Length < 5)
            {
                MessageBox.Show("Min. 5 karakter hosszú legyen a jelszó!");
                passwordTextBox_r.Focus();
            }
            else if (passwordTextBox_r.Password != passwordTextBox_r2.Password)
            {
                MessageBox.Show("A két jelszó nem egyezik!");
                passwordTextBox_r2.Focus();
            }
            else if (nameTextBox_r.Text.Length < 5)
            {
                MessageBox.Show("Adja meg a nevét!");
                nameTextBox_r.Focus();
            }
            else if (!Regex.IsMatch(nameTextBox_r.Text, @"^[a-zA-Z]{1,20} [a-zA-Z]{1,20}"))
            {
                MessageBox.Show("Helytelen név!");
                nameTextBox_r.Focus();
            }
            else if (addressTextBox_r.Text.Length < 5)
            {
                MessageBox.Show("Adja meg a címét!");
                addressTextBox_r.Focus();
            }
            else if (!Regex.IsMatch(addressTextBox_r.Text, @"^[0-9]{1,4} [a-zA-Z]{1,20} [a-zA-Z\\s]{1,20}"))
            {
                MessageBox.Show("Helytelen cím!");
                addressTextBox_r.Focus();
            }
            else
            {
                if (Lib.UserExists(usernameTextBox_r.Text))
                {
                    MessageBox.Show("A felhasználónév már létezik!");
                    usernameTextBox_r.Focus();
                }
                else
                {
                    if (Lib.tryRegister(emailTextBox_r.Text, usernameTextBox_r.Text, passwordTextBox_r.Password, nameTextBox_r.Text, addressTextBox_r.Text))
                    {
                        MessageBox.Show("Sikeres regisztráció!\nKérem jelentkezzen be!");
                        rD();
                    }
                }
            }
        }
    }
}



/*
To match any letter character from any language use:

\p{L}

If you also want to match numbers:

[\p{L}\p{Nd}]+

\p{L} ... matches a character of the unicode category letter.
                it is the short form for [\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo}]
                  \p{Ll} ... matches lowercase letters. (abc)
                  \p{Lu} ... matches uppercase letters. (ABC)
                  \p{Lt} ... matches titlecase letters.
                  \p{Lm} ... matches modifier letters.
                  \p{Lo} ... matches letters without case. (中文)

\p{Nd} ... matches a character of the unicode category decimal digit.

Just replace: ^[a-zA-Z0-9\s]+$ with ^[\p{L}0-9\s]+$

*/
