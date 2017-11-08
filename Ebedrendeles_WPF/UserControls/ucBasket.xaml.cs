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
    /// Interaction logic for ucBasket.xaml
    /// </summary>
    public partial class ucBasket : UserControl
    {
        public User USER;
        public cnAdatbazis cnDB = new cnAdatbazis();
        public int vegosszeg;
        private const int MENU_AR = 1000;
        public ucBasket(User u)
        {
            InitializeComponent();
            USER = u;

            Betolt();
        }

        public void Betolt() //a kosar tartalmanak betoltese
        {
            List<int> i1 = new List<int>();
            foreach(tartalom t in USER.kosar)
            {
                if (t.isalacarte)
                    i1.Add(t.menuid);
            }

            List<int> i2 = new List<int>();
            foreach (tartalom t in USER.kosar)
            {
                if (!t.isalacarte)
                    i2.Add(t.menuid);
            }

            var items1 = from x in cnDB.enEtelekSet where i1.Contains(x.etelekID) select x;
            dgAlac.ItemsSource = items1.ToList();

            var items2 = from x in cnDB.enNetelekSet where i2.Contains(x.napietelekID) select x;
            dgMenus.ItemsSource = items2.ToList();

            vegosszeg = items2.ToList().Count * MENU_AR;
            if (items2.ToList().Count >= 5)
                vegosszeg = (int)(vegosszeg * 0.9);

            foreach(enEtelek e in items1.ToList())
                vegosszeg += e.ar;

            if (vegosszeg > 0)
                vegosszegTb.Text = vegosszeg.ToString() + " Ft";
            else
                vegosszegTb.Text = "";
        }

        private void dgMenus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dgMenus.SelectedItem = null;
        }

        private void dgMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMenus.SelectedIndex != -1)
            {
                enNetelek item = ((enNetelek)dgMenus.SelectedItem);

                spSave.Visibility = Visibility.Visible;
                rbFirst.Content = item.foetel1;
                rbSecond.Content = item.foetel2;
                rbThird.Content = item.foetelvega;

                tartalom tr = USER.kosar[getMenuIndexInBasket(item.napietelekID)];
                rbFirst.IsChecked = false;
                rbSecond.IsChecked = false;
                rbThird.IsChecked = false;

                if (tr.foetel == "foetel1")
                    rbFirst.IsChecked = true;
                else if (tr.foetel == "foetel2")
                    rbSecond.IsChecked = true;
                else
                    rbThird.IsChecked = true;
            }
            else
                spSave.Visibility = Visibility.Collapsed;
        }

        private void dgAlac_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dgAlac.SelectedItem = null;
        }

        private void dgAlac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAlac.SelectedIndex != -1)
            {
                enEtelek item = ((enEtelek)dgAlac.SelectedItem);
                tartalom tr = USER.kosar[getFoodIndexInBasket(item.etelekID)];

                dpDate.SelectedDate = tr.alacarte_date;

                btSaveFood.Visibility = Visibility.Visible;
                dpDate.Visibility = Visibility.Visible;
                btDeleteFood.Visibility = Visibility.Visible;
            }
            else
            {
                btSaveFood.Visibility = Visibility.Hidden;
                dpDate.Visibility = Visibility.Hidden;
                btDeleteFood.Visibility = Visibility.Hidden;
                dpDate.SelectedDate = null;
            }
        }

        private void btSaveFood_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.SelectedDate == null)
            {
                MessageBox.Show("Kérem válasszon dátumot!");
                return;
            }

            try
            {
                tartalom t = new tartalom();
                t.isalacarte = true;
                t.menuid = ((enEtelek)dgAlac.SelectedItem).etelekID;
                t.alacarte_date = DateTime.Parse(dpDate.SelectedDate.ToString());
                int id = getFoodIndexInBasket(t.menuid);
                USER.kosar[id] = t; // frissíti elvileg

                MessageBox.Show("Sikeresen módosítva!");

                dgAlac.SelectedItem = null;
                btSaveFood.Visibility = Visibility.Hidden;
                dpDate.Visibility = Visibility.Hidden;
                btDeleteFood.Visibility = Visibility.Hidden;
                dpDate.SelectedDate = null;

                Betolt();
            }
            catch (Exception) { }
        }

        private void btDeleteFood_Click(object sender, RoutedEventArgs e) //alacarte torlesek a kosarbol
        {
            if (MessageBox.Show("Biztosan törli az ételt a rendelések közül?", "Törlés", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            try
            {
                int id = getFoodIndexInBasket(((enEtelek)dgAlac.SelectedItem).etelekID);
                USER.kosar.RemoveAt(id);

                dgAlac.SelectedItem = null;
                btSaveFood.Visibility = Visibility.Hidden;
                dpDate.Visibility = Visibility.Hidden;
                btDeleteFood.Visibility = Visibility.Hidden;
                dpDate.SelectedDate = null;

                Betolt();
            }
            catch (Exception) { }
        }

        private void btSaveMenu_Click(object sender, RoutedEventArgs e) //etelek modositasa
        {
            try
            {
                tartalom t = new tartalom();
                t.isalacarte = false;
                t.menuid = ((enNetelek)dgMenus.SelectedItem).napietelekID;
                t.foetel = (bool)rbFirst.IsChecked ? "foetel1" : ((bool)rbSecond.IsChecked ? "foetel2" : "foetelvega");

                int id = getMenuIndexInBasket(t.menuid);
                USER.kosar[id] = t; // frissíti elvileg

                MessageBox.Show("Sikeresen módosítva!");

                dgMenus.SelectedItem = null;
                spSave.Visibility = Visibility.Collapsed;

                Betolt();
            }
            catch (Exception) { }
        }

        private void btDeleteMenu_Click(object sender, RoutedEventArgs e) //menuk torlese a kosarbol
        {
            if (MessageBox.Show("Biztosan törli a menüt a rendelések közül?", "Törlés", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            try
            {
                int id = getMenuIndexInBasket(((enNetelek)dgMenus.SelectedItem).napietelekID);
                USER.kosar.RemoveAt(id);

                dgMenus.SelectedItem = null;
                spSave.Visibility = Visibility.Collapsed;

                Betolt();
            }
            catch (Exception) { }
        }

        public int getMenuIndexInBasket(int menuID)
        {
            for (int i = 0; i < USER.kosar.Count; i++)
            {
                if (!USER.kosar[i].isalacarte && USER.kosar[i].menuid == menuID)
                    return i;
            }
            return -1;
        }
        public int getFoodIndexInBasket(int alacID)
        {
            for (int i = 0; i < USER.kosar.Count; i++)
            {
                if (USER.kosar[i].isalacarte && USER.kosar[i].menuid == alacID)
                    return i;
            }
            return -1;
        }

        private void btOrder_Click(object sender, RoutedEventArgs e) //rendeles megerositese
        {
            if (USER.kosar.Count <= 0)
                return;

            if (MessageBox.Show("Biztosan megrendeli?", "Kosár", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            int orderid = Lib.uploadOrder(vegosszeg, DateTime.Now, USER.userid);

            foreach (tartalom t in USER.kosar)
            {
                if (t.isalacarte)
                    Lib.addOrderFood(orderid, t.alacarte_date, t.menuid);
                else
                    Lib.addOrderMenu(orderid, t.foetel, t.menuid);
            }
            MessageBox.Show("Rendelés leadva!");

            USER.kosar.Clear();
            Betolt();
        }
    }
}
