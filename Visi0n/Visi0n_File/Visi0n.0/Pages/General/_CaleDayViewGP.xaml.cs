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

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for _CaleDayViewGP.xaml
    /// </summary>
    public partial class _CaleDayViewGP : Page
    {
        Frame _frame;
        string _date;
        ListViewItem _selected;

        public _CaleDayViewGP(Frame frame, string date, ListViewItem LVI)
        {
            InitializeComponent();

            _frame = frame;
            _date = date;
            _selected = LVI;

            DateStringLabel.Content = _date;

            if (LVI != null) EventList.Items.Add(new ListViewItem { Content = LVI.Content.ToString()});
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new CalendarGP(_frame));
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new __CaleActionGP(_frame, _date));
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            _selected = (ListViewItem)sender;
        }
    }
}
