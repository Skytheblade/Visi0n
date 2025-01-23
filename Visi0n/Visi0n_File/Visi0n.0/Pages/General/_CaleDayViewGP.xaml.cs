using System;
using System.Collections;
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
using Visi0n._0.VModel;

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for _CaleDayViewGP.xaml
    /// </summary>
    public partial class _CaleDayViewGP : Page
    {
        Frame _frame;
        User _user;
        string _date;
        ObservableCollection<Event> _events = new ObservableCollection<Event>();
        Event _selected;

        public _CaleDayViewGP(Frame frame, User u, string date, ObservableCollection<Event> e)
        {
            InitializeComponent();

            _frame = frame;
            _date = date;
            _events = e;
            _user = u;

            EventList.Items.Clear();
            EventList.ItemsSource = _events;

            DateStringLabel.Content = _date;

            //if (_selected != null) EventList.Items.Add(new ListViewItem { Content = _selected._name});
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new CalendarGP(_frame, _user));
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            //_frame.Navigate(new __CaleActionGP(_frame, _date));
        }

        private void EventList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selected = EventList.SelectedItem as Event;
        }
    }
}
