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
using System.Windows.Shapes;

namespace ColorfulRing
{
    /// <summary>
    /// Interaction logic for RingsWithLinkList.xaml
    /// </summary>
    public partial class RingsWithLinkList : Window
    {
        private StackWithLinkList Bar1;
        private StackWithLinkList Bar2;
        private StackWithLinkList Bar3;
        private int[] RingList1;
        private int[] RingList2;
        private int[] RingList3;
        public RingsWithLinkList()
        {
            InitializeComponent();
            Bar1 = new StackWithLinkList();
            Bar2 = new StackWithLinkList();
            Bar3 = new StackWithLinkList();
            RingList1 = new int[15];
            RingList2 = new int[15];
            RingList3 = new int[15];
            Bar1.Statuse += Stack_Statuse;
            Bar2.Statuse += Stack_Statuse;
            Bar3.Statuse += Stack_Statuse;
            MakeRandomNumber();
            Show();
        }
        private void Stack_Statuse(object sender, string e)
        {
            txtWarnnig.Text = e;
        }
        private void nextto2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtWarnnig.Text = "";
            Bar2.Push(Bar1.Pop());
            Show();
            Check();
        }

        private void backto1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtWarnnig.Text = "";
            Bar1.Push(Bar2.Pop());
            Show();
            Check();
        }

        private void nextto3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtWarnnig.Text = "";
            Bar3.Push(Bar2.Pop());
            Show();
            Check();
        }

        private void backto2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtWarnnig.Text = "";
            Bar2.Push(Bar3.Pop());
            Show();
            Check();
        }
        private void MakeRandomNumber()
        {
            Random random = new Random();
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < 15; i++)
            {
                do
                {
                    number = random.Next(1, 16); // between 1 ta 15
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
                if (i <= 4)
                    Bar1.Push(listNumbers[i]);
                else if (i <= 9)
                    Bar2.Push(listNumbers[i]);
                else
                    Bar3.Push(listNumbers[i]);

                //for testing check Method ;
                //Bar1.Push(i);
            }
        }
        private void Show()
        {
            lblstatus.Content = "";
            List1.Items.Clear();
            List2.Items.Clear();
            List3.Items.Clear();
            RingList1 = Bar1.Rings();
            RingList2 = Bar2.Rings();
            RingList3 = Bar3.Rings();
            for (int i = 14; i >= 0; i--)
            {
                if (RingList1[i] != 0)
                    List1.Items.Add(RingList1[i]);
                if (RingList2[i] != 0)
                    List2.Items.Add(RingList2[i]);
                if (RingList3[i] != 0)
                    List3.Items.Add(RingList3[i]);
            }
        }
        private void Check()
        {
            bool Complete = false;
            if (Bar1.Size() == 15)
            {
                if (isAscendingSort(Bar1) || isDescendingSort(Bar1))
                    Complete = true;

            }
            else if (Bar2.Size() == 15)
            {
                if (isAscendingSort(Bar2) || isDescendingSort(Bar2))
                    Complete = true;
            }
            else // Bar3.Size() == 15
            {
                if (isAscendingSort(Bar3) || isDescendingSort(Bar3))
                    Complete = true;
            }
            if (Complete)
            {
                lblstatus.Foreground = new SolidColorBrush(Colors.Green);
                lblstatus.Content = "Cool  Winning.............";
                return;
            }
            lblstatus.Content = "Not Winning Yet........";
        }

        private bool isAscendingSort(StackWithLinkList stack)
        {
            int last = 14;
            int i = 0;
            int[] temp = stack.Rings();
            while (i < last && temp[i] < temp[i + 1])
                i++;
            return i == last;
        }
        private bool isDescendingSort(StackWithLinkList stack)
        {
            int last = 14;
            int i = 0;
            int[] temp = stack.Rings();
            while (i < last && temp[i] < temp[i + 1])
                i++;
            return i == last;
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Visibility = Visibility.Visible;
        }
    }
}
