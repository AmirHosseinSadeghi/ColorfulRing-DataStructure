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

namespace ColorfulRing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            RingsWithLinkList rings = new RingsWithLinkList();
            this.Visibility = Visibility.Hidden;
            rings.Visibility = Visibility.Visible;
        }

        private void btnarray_Click(object sender, RoutedEventArgs e)
        {
            RingsPage rings = new RingsPage();
            this.Visibility = Visibility.Hidden;
            rings.Visibility = Visibility.Visible;
        }
    }
}
