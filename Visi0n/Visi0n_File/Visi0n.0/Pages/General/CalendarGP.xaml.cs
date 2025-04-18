using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Model_;
using VModel_;

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// no idea what I have done here
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
        //ObservableCollection<Event> _events; //same as list, but might be better sometimes
        DateCaleReader dc;


        public CalendarGP(Frame frame, User usr)
        {
            InitializeComponent();
            _frame = frame;
            _usr = usr;

             //_events = EventService.Load(_usr);

            Marr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Ynum = 2024;

            MarrIndx = 10;
            Month.Content = Marr[MarrIndx].ToString();
            Year.Content = Ynum.ToString();
            _day = 1;
            UpdateDate();

            dc = new DateCaleReader(new RadioButton[] 
            {   d1, d2, d3, d4, d5, d6, d7, d8, d9, d10,
                d11, d12, d13, d14, d15, d16, d17, d18, d19, d20, 
                d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31 }, _usr);
            dc.ReColor(__date);
        }

        private void UpdateDate()
        {
            string ddd;
            string mmm;
            if (_day < 10) ddd = "0" + _day; else ddd = "" + _day;
            if (Marr[MarrIndx] < 10) mmm = "0" + Marr[MarrIndx]; else mmm = "" + Marr[MarrIndx];
            __date = " " + ddd + " / " + mmm + " / " + Ynum;
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
            dc.ReColor(__date);
        }

        private void nxtM_Click(object sender, RoutedEventArgs e)
        {
            if (MarrIndx > 10) MarrIndx = 0;
            else
                MarrIndx++;

            Month.Content = Marr[MarrIndx].ToString();
            UpdateDate();
            UpdateColumn();
            dc.ReColor(__date);
        }

        private void preY_Click(object sender, RoutedEventArgs e)
        {
            Ynum--;
            Year.Content = Ynum.ToString();
            UpdateDate();
            UpdateColumn();
            dc.ReColor(__date);
        }

        private void nxtY_Click(object sender, RoutedEventArgs e)
        {
            Ynum++;
            Year.Content = Ynum.ToString();
            UpdateDate();
            UpdateColumn();
            dc.ReColor(__date);
        }


        private void d_Checked(object sender, RoutedEventArgs e)
        {
            _day = int.Parse(((RadioButton)sender).Content.ToString());
            UpdateDate();
            UpdateColumn();
        }

        private void d_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //ObservableCollection<Event> storm = EventService.Vortex(_usr, __date.Replace(" ", ""));
            _frame.Navigate(new _CaleDayViewGP(_frame, _usr, __date));
        }



        internal class DateCaleReader
        {
            User uu;
            RadioButton[] Total;

            public DateCaleReader(RadioButton[] arr, User uu)
            {
                Total = arr;
                this.uu = uu;
            }

            public void ReColor(string rawdate)
            {
                ColorRaw();
                string _m = rawdate.Replace(" ", "").Split("/")[1]; string _y = rawdate.Replace(" ", "").Split("/")[2];
                ColorPersonal(_m, _y);
                ColorCorp(_m, _y);
            }

            public void ColorRaw()
            {
                foreach (RadioButton r in Total)
                {
                    r.Background = Brushes.Beige;
                }
            }

            public void ColorPersonal(string _m, string _y)
            {
                List<string> days = EventService.ActiveDays(uu._absId, _m, _y);
                foreach (string d in days)
                {
                    foreach(RadioButton r in Total) if (r.Name == "d" + int.Parse(d)) r.Background = Brushes.Pink;
                }
            }

            public void ColorCorp(string _m, string _y)
            {
                List<string> days = EventService.SuperActiveDays(uu._absId, _m, _y);
                foreach (string d in days)
                {
                    foreach (RadioButton r in Total) if (r.Name == "d" + int.Parse(d)) r.Background = Brushes.Plum;
                }
            }

            RadioButton[] ReturnAll() => Total;
        }
    }
}
