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
using Ebedrendeles_WPF.UserControls;
using System.IO;

namespace Ebedrendeles_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User USER = new User();
        public MainWindow()
        {
            InitializeComponent();

            var DataDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName) + "\\Ebedrendeles_adatbazis";
            AppDomain.CurrentDomain.SetData("DataDirectory", DataDir);

           // loggedIn("admin", "admin", true);
        }

        public void miClick(object sender, EventArgs e) // usercontrolok közötti navigáció
        {
            switch (((MenuItem) sender).Name)
            {
                case "miLogin":
                    if (!USER.isLoggedIn()) //ha nincs belepve es regisztralt
                    {
                        registrated();
                    }   
                    break;
                case "miRegistration":
                    if (!USER.isLoggedIn()) //ha nincs belepve atlep a regisztracios UC-ra
                    {
                        ucRegistration uc = new ucRegistration();
                        uc.USER = USER;
                        uc.rD = registrated;
                        ccWindow.Content = uc;
                    }
                    break;
                case "miAlaC": //alacarte UC
                    {
                        ucAlaC uc = new ucAlaC();
                        uc.USER = USER;
                        ccWindow.Content = uc;
                    }
                    break;
                case "miMenu": //menuk UC
                    {
                        ucMenu uc = new ucMenu();
                        uc.USER = USER;
                        ccWindow.Content = uc;
                    }
                    break;
                case "miBasket": //kosar UC
                    if (USER.isLoggedIn())
                    {
                        ucBasket uc = new ucBasket(USER);
                        ccWindow.Content = uc;
                    }
                    break;
                case "miOrders": //rendelesek UC
                    if (USER.isLoggedIn())
                    {
                        ucOrders uc = new ucOrders(USER);
                        ccWindow.Content = uc;
                    }
                    break;
                case "miOptions": //beallitasok UC
                    if (USER.isLoggedIn())
                    {
                        ucOptions uc = new ucOptions(USER);
                        ccWindow.Content = uc;
                    }
                    break;
                case "miLogout": //kijelentkezes
                    if (USER.isLoggedIn())
                    {
                        logout();
                    }
                    break;
                case "miStatistic": //statisztika UC, csak ha adminkent belepve
                    if (USER.isLoggedIn() && USER.isadmin)
                    {
                        ucStatistic uc = new ucStatistic();
                        uc.USER = USER;
                        ccWindow.Content = uc;
                    }
                    break;
                case "miUsers": //felhasznalok UC, csak ha adminkent belepve
                    if (USER.isLoggedIn() && USER.isadmin)
                    {
                        ucUsers uc = new ucUsers();
                        uc.USER = USER;
                        ccWindow.Content = uc;
                    }
                    break;
                case "miMenuFood": //menuk es etelek felvitele, csak ha adminkent belepve
                    if (USER.isLoggedIn() && USER.isadmin)
                    {
                        ucMenuFood uc = new ucMenuFood();
                        uc.USER = USER;
                        ccWindow.Content = uc;
                    }
                    break;

                default:
                    break;
            }
        }

        public void loggedIn(string user, string pass, bool isAdmin)
        {
            USER.username = user;
            USER.password = pass;
            USER.isadmin = isAdmin;
            USER.userid = Lib.getUserId(user);

            if (isAdmin)
            {
                // set admin menus to visible
                miAdmin.Visibility = Visibility.Visible;

                ucStatistic uc = new ucStatistic();
                uc.USER = USER;
                ccWindow.Content = uc;
            }
            else
            {
                ucMenu uc = new ucMenu();
                uc.USER = USER;
                ccWindow.Content = uc;
            }

            miLogin.Visibility = Visibility.Collapsed;
            miRegistration.Visibility = Visibility.Collapsed;

            miBasket.Visibility = Visibility.Visible;
            miOrders.Visibility = Visibility.Visible;
            miOptions.Visibility = Visibility.Visible;
            miLogout.Visibility = Visibility.Visible;

            // átnavigálás menükre pl
            
        }

        public void registrated()
        {
            // vissza navigálás
            ucLogin uc = new ucLogin();
            uc.lD = loggedIn;
            uc.USER = USER;
            ccWindow.Content = uc;
        }

        public void logout()
        {
            // kiléptetés
            miBasket.Visibility = Visibility.Collapsed;
            miOrders.Visibility = Visibility.Collapsed;
            miOptions.Visibility = Visibility.Collapsed;
            miLogout.Visibility = Visibility.Collapsed;
            miAdmin.Visibility = Visibility.Hidden;

            miLogin.Visibility = Visibility.Visible;
            miRegistration.Visibility = Visibility.Visible;

            USER = new User();
            registrated();
        }
    }
}
