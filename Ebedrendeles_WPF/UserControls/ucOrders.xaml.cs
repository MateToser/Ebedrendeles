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
    /// Interaction logic for ucOrders.xaml
    /// </summary>
    public partial class ucOrders : UserControl
    {
        public User USER;
        public List<enKosar> orders;
        public ucOrders(User u)
        {
            InitializeComponent();
            USER = u;

            Betolt();
        }

        public void Betolt() //a rendelesek betoltese
        {
            try
            {
                orders = Lib.getMyOrders(USER.userid);
                dgOrders.ItemsSource = orders;
            }
            catch (Exception) { }
        }

        private void dgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e) //ha kevesebb mint 24 oraja rendelt, meg valtoztathat
        {
            if(dgOrders.SelectedIndex != -1)
            {
                enKosar sel = ((enKosar)dgOrders.SelectedItem);
                TimeSpan ts = (TimeSpan)(DateTime.Now - sel.rendelesido);

                if(ts.TotalMinutes < 1440)
                {
                    btDeleteOrder.Visibility = Visibility.Visible;
                    return;
                }
            }
            btDeleteOrder.Visibility = Visibility.Hidden;
        }

        private void dgOrders_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dgOrders.SelectedItem = null;
        }

        private void btDeleteOrder_Click(object sender, RoutedEventArgs e) //rendeles torlese
        {
            if (dgOrders.SelectedIndex == -1)
                return;

            if (MessageBox.Show("Biztosan törli a megrendelést?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            enKosar sel = ((enKosar)dgOrders.SelectedItem);

            Lib.removeOrderFoodAll(sel.rendelesID);
            Lib.removeOrderMenuAll(sel.rendelesID);
            Lib.removeOrder(sel.rendelesID);

            MessageBox.Show("Megrendelés törölve!");
            Betolt();
        }
    }
}
