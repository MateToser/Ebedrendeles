using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ucMenuFood.xaml
    /// </summary>
    public partial class ucMenuFood : UserControl
    {
        public User USER;
        public byte[] PictureBytes;
        public ucMenuFood()
        {
            InitializeComponent();
        }

        private void btMenuUpload(object sender, RoutedEventArgs e)
        {
            // menü felvitele
            if (MessageBox.Show("Biztosan hozzáadja a menüt?", "Menü hozzáadása", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            try
            {
                if (Lib.tryUploadMenuFood(tbMenuLeves.Text, tbMenuElso.Text, tbMenuMasodik.Text, tbMenuHarmadik.Text, tbMenuDesszert.Text, DateTime.Parse(tbMenuDatum.Text)))
                {
                    MessageBox.Show("Menü sikeresen felvéve!");
                    tbMenuLeves.Text = "";
                    tbMenuElso.Text = "";
                    tbMenuMasodik.Text = "";
                    tbMenuHarmadik.Text = "";
                    tbMenuDesszert.Text = "";
                    tbMenuDatum.Text = "";
                }
                else
                    MessageBox.Show("Hiba történt a menü felvitele során!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba történt a menü felvitele során, ellenőrizze az adatok helyességét!");
            }
        }

        private void btSelectImg(object sender, RoutedEventArgs e) //kep feltoltese
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Kérem válassza ki a képet!";
            if (dialog.ShowDialog() == true)
                PictureBytes = File.ReadAllBytes(dialog.FileName);
        }

        private void btUpload(object sender, RoutedEventArgs e) //etel hozzaadasa
        {
            // alacarte
            if (MessageBox.Show("Biztosan hozzáadja az ételt?", "Étel hozzáadása", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            if (PictureBytes == null)
            {
                MessageBox.Show("Kérem tallózon képet az ételhez!");
                return;
            }

            try
            {
                if (Lib.tryUploadFood(cbKategoria.Text, tbNev.Text, int.Parse(tbAr.Text), PictureBytes))
                {
                    MessageBox.Show("Étel sikeresen felvéve!");
                    tbNev.Text = "";
                    tbAr.Text = "";
                    PictureBytes = null;
                }
                else
                    MessageBox.Show("Hiba történt az étel felvitele során!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba történt az étel felvitele során, ellenőrizze az adatok helyességét!");
            }
        }
    }
}
