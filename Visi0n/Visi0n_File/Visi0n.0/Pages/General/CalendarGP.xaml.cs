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
using Visi0n._0.Pages.Pesonal;
using Visi0n._0.VModel;

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for CalendarGP.xaml
    /// </summary>
    public partial class CalendarGP : Page
    {

        Frame _frame;
        int _day;
        int[] Marr;
        int MarrIndx;
        int Ynum;
        string __date;

        User _usr;


        public CalendarGP(Frame frame, User usr = null)
        {
            InitializeComponent();
            _frame = frame;

            Marr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Ynum = 2024;

            MarrIndx = 10;
            Month.Content = Marr[MarrIndx].ToString();
            Year.Content = Ynum.ToString();
            _day = 1;
            UpdateDate();
        }

        private void UpdateDate()
        {
            __date = " " + _day + " / " + Marr[MarrIndx] + " / " + Ynum;
            TheDateOfToday.Content = __date;
        }
        private void UpdateColumn()
        {
            DateText.Content = __date;
        }

        private void preM_Click(object sender, RoutedEventArgs e)
        {
            if (MarrIndx < 1) MarrIndx = 11;
            else
                MarrIndx--;

            Month.Content = Marr[MarrIndx].ToString();
            UpdateDate();
            UpdateColumn();
        }

        private void nxtM_Click(object sender, RoutedEventArgs e)
        {
            if (MarrIndx > 10) MarrIndx = 0;
            else
                MarrIndx++;

            Month.Content = Marr[MarrIndx].ToString();
            UpdateDate();
            UpdateColumn();
        }

        private void preY_Click(object sender, RoutedEventArgs e)
        {
            Ynum--;
            Year.Content = Ynum.ToString();
            UpdateDate();
            UpdateColumn();
        }

        private void nxtY_Click(object sender, RoutedEventArgs e)
        {
            Ynum++;
            Year.Content = Ynum.ToString();
            UpdateDate();
            UpdateColumn();
        }


        private void d_Checked(object sender, RoutedEventArgs e)
        {
            _day = int.Parse(((RadioButton)sender).Content.ToString());
            UpdateDate();
            UpdateColumn();
        }

        private void d_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new _CaleDayViewGP(_frame, __date, null));
        }
    }
}
