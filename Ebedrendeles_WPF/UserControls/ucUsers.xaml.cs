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
    /// Interaction logic for ucUsers.xaml
    /// </summary>
    public partial class ucUsers : UserControl
    {
        public User USER;
        public ucUsers()
        {
            InitializeComponent();

            Betolt();
        }

        public void Betolt() //a felhasznaloi adatok betoltese az admin szamara
        {
            try
            {
                dgUsers.ItemsSource = Lib.getAllUser();
            }
            catch (Exception) { }
        }
    }
}
