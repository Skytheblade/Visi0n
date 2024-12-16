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

namespace Visi0n._0.Pages.Pesonal
{
    /// <summary>
    /// Interaction logic for CalendarDayViewP.xaml
    /// </summary>
    public partial class CalendarDayViewP : Page
    {
        Frame _frame;
        string _day;
        string _label;

        public CalendarDayViewP(Frame frame, string day, string label)
        {
            InitializeComponent();

            _frame = frame;
            _day = day;
            _label = label;

            DateStringLabel.Content = int.Parse(day) + " " + _label;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new CaleAction(_frame, _day, _label));
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new CalendarPage(_frame));
        }
    }
}
