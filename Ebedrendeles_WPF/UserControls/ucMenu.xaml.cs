using Ebedrendeles_adatbazis;
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

namespace Ebedrendeles_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for ucMenu.xaml
    /// </summary>
    public partial class ucMenu : UserControl
    {
        public User USER;
        public cnAdatbazis cnDB = new cnAdatbazis();
        public ucMenu()
        {
            InitializeComponent();

            Betolt();
        }

        public void Betolt() //menuk betoltese datagridbe
        {
            var items = from x in cnDB.enNetelekSet select x; // new { x.napietelekID, x.datum, x.leves, x.foetel1, x.foetel2, x.foetelvega, x.desszert };
            dgMenus.ItemsSource = items.ToList();
        }

        private void dgMenus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!USER.isLoggedIn())
            {
                e.Handled = true;
                return;
            }

            dgMenus.SelectedItem = null;
        }

        private void dgMenus_SelectionChanged(object sender, SelectionChangedEventArgs e) //a menuk kivalasztasa
        {
            if (!USER.isLoggedIn())
            {
                e.Handled = true;
                return;
            }

            if (dgMenus.SelectedIndex != -1)
            {
                enNetelek item = ((enNetelek)dgMenus.SelectedItem);

                foreach (tartalom t in USER.kosar)
                {
                    if (!t.isalacarte && t.menuid == item.napietelekID)
                    {
                        MessageBox.Show("Már tartalmazza a kosár az alábbi menüt!");
                        dgMenus.SelectedItem = null;
                        e.Handled = true;
                        return;
                    }
                }

                spSave.Visibility = Visibility.Visible;
                rbFirst.Content = item.foetel1;
                rbSecond.Content = item.foetel2;
                rbThird.Content = item.foetelvega;

                rbFirst.IsChecked = true;
            }
            else
                spSave.Visibility = Visibility.Collapsed;
        }

        private void btSave_Click(object sender, RoutedEventArgs e) //kosarhoz adas
        {
            if (!USER.isLoggedIn())
            {
                e.Handled = true;
                return;
            }

            try
            {
                tartalom t = new tartalom();
                t.isalacarte = false;
                t.menuid = ((enNetelek)dgMenus.SelectedItem).napietelekID;
                t.foetel = (bool)rbFirst.IsChecked ? "foetel1" : ((bool)rbSecond.IsChecked ? "foetel2" : "foetelvega");

                USER.kosar.Add(t);
                MessageBox.Show("Hozzáadva a kosárhoz!");

                dgMenus.SelectedItem = null;
                spSave.Visibility = Visibility.Collapsed;
            }
            catch (Exception) { }
        }
    }
}
