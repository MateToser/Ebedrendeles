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
    /// Interaction logic for ucStatistic.xaml
    /// </summary>
    public partial class ucStatistic : UserControl
    {
        public User USER;
        public ucStatistic()
        {
            InitializeComponent();

            Betolt();
        }

        public void Betolt() //a 3 legtobbet vasarolt etel betoltese
        {
            dgFoodStat.ItemsSource = Lib.getTop3Food();
        }
    }
}
