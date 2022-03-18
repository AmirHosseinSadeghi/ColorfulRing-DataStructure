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
    /// Interaction logic for RingsPage.xaml
    /// </summary>
    public partial class RingsPage : Window
    {
        private Stack Bar1;
        private Stack Bar2;
        private Stack Bar3;
        public RingsPage()
        {
            InitializeComponent();
            Bar1 = new Stack();
            Bar2 = new Stack();
            Bar3 = new Stack();
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
            for (int i = 14; i >= 0; i--)
            {
                if (Bar1.RingList[i] != 0)
                    List1.Items.Add(Bar1.RingList[i]);
                if (Bar2.RingList[i] != 0)
                    List2.Items.Add(Bar2.RingList[i]);
                if (Bar3.RingList[i] != 0)
                    List3.Items.Add(Bar3.RingList[i]);
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

        private bool isAscendingSort(Stack stack)
        {
            //bool result = false;
            //for (int i = 1; i < 15; i++)
            //{
            //    if (stack.RingList[i - 1] < stack.RingList[i])
            //        result = true;
            //    else
            //        result = false;
            //}
            //return result;
            int last = 14;
            int i = 0;
            while (i < last && stack.RingList[i] < stack.RingList[i + 1])
                i++;
            return i == last;
        }
        private bool isDescendingSort(Stack stack)
        {
            int last = 14;
            int i = 0;
            while (i < last && stack.RingList[i] > stack.RingList[i + 1])
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
