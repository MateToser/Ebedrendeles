using Ebedrendeles_adatbazis;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ucAlaC.xaml
    /// </summary>
    public partial class ucAlaC : UserControl
    {
        public User USER;
        public cnAdatbazis cnDB = new cnAdatbazis();
        public ucAlaC()
        {
            InitializeComponent();

            Betolt();
        }

        public void Betolt() //etelek beoltese a datagrid-be
        {
            var items = from x in cnDB.enEtelekSet select x; //{ x.etelekID, x.kep, x.nev, x.kategoria, x.ar };
            dgAlac.ItemsSource = items.ToList();
        }

        private void dgAlac_SelectionChanged(object sender, SelectionChangedEventArgs e) //datagrid-ben kivalasztani az alacarte-t
        {
            if (!USER.isLoggedIn()) //akkor lehetseges ha be van lepve
            {
                e.Handled = true;
                return;
            }

            if(dgAlac.SelectedIndex != -1)
            {
                btSave.Visibility = Visibility.Visible;
                dpDate.Visibility = Visibility.Visible;
            }
            else
            {
                btSave.Visibility = Visibility.Hidden;
                dpDate.Visibility = Visibility.Hidden;
                dpDate.SelectedDate = null;
            }
        }

        private void dgAlac_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!USER.isLoggedIn())
            {
                e.Handled = true;
                return;
            }

            dgAlac.SelectedItem = null;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (!USER.isLoggedIn())
            {
                e.Handled = true;
                return;
            }

            if (dpDate.SelectedDate == null)
            {
                MessageBox.Show("Kérem válasszon dátumot!");
                return;
            }

            try //kosarhoz hozzaadas, ha mindent kivalasztott
            {
                tartalom t = new tartalom();
                t.isalacarte = true;
                t.alacarte_date = DateTime.Parse(dpDate.SelectedDate.ToString());
                t.menuid = ((enEtelek)dgAlac.SelectedItem).etelekID;

                USER.kosar.Add(t);
                MessageBox.Show("Hozzáadva a kosárhoz!");

                dgAlac.SelectedItem = null;
            }
            catch (Exception) { }
        }
    }
}
