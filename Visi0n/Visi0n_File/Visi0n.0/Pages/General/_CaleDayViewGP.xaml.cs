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
using Model_;
using VModel_;

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

        int posCur;

        public _CaleDayViewGP(Frame frame, User u, string date, ObservableCollection<Event> storm, Event edited = null)
        {
            InitializeComponent();

            _frame = frame;
            _date = date;
            _events = storm;
            _user = u;

            if (edited != null) {
                bool f = false;
                foreach (Event e in _events)
                {
                    if (e._ID == edited._ID) f = true;
                }
                if (f)
                {
                    // update db
                }
                else
                {
                    _events.Add(edited);
                    // add to db
                }
                // check edit
                // if new - add
                // if edited - replace
                // write to db
                // identifier - ID
                // needs fixing
            }

            posCur = 0;

            //EventList.Items.Clear();
            //EventList.ItemsSource = _events;

            DateStringLabel.Content = _date;

            Inprint(_events);

            //if (_selected != null) EventList.Items.Add(new ListViewItem { Content = _selected._name});
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new CalendarGP(_frame, _user));
        }


        public void Inprint(ObservableCollection<Event> evs)
        {
            //ObservableCollection<Event> eev = new ObservableCollection<Event>();
            //foreach (Event ev in evs) { eev.Add(ev); }
            for (int i = 0; i < evs.Count; i++)
            {
                AddItem(evs[i]);
            }
        }
        private void AddItem(Event ev)
        {
            Label label = new Label() { Content = ev._name /* + "; " + ev._ID*/, Margin = new Thickness(5, 5, 5, 5),  };
            label.Style = (Style)FindResource("Note01");
            Grid.SetRow(label, posCur);
            label.MouseDown += new MouseButtonEventHandler(label_MouseDown);
            Table.Children.Add(label);
            posCur++;
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string idd = ((Label)sender).Content.ToString();
            //id = id.Replace(" ", "");
            //id = id.Split(';')[1];
            int id = EventService.FindId(idd, _user, _date);

            foreach(Event eve in _events)
            {
                if (eve._ID == id) _selected = eve;
            }

            MessageBox.Show(_selected._ID +"\n"+ _selected._name +"\n"+ _selected._description +"\n"+ _selected._date +"\n"+ _selected._uid);
        }


        private void AD_Click(object sender, RoutedEventArgs e)
        {
            if (_selected != null) MessageBox.Show("Selected: " + _selected._name);
            _frame.Navigate(new __CaleActionGP(_frame, _user, _date, _events));
        }

        private void ED_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null) MessageBox.Show("Please select an event first");
            else
            {
                MessageBox.Show("Selected: " + _selected._name);
                _frame.Navigate(new __CaleActionGP(_frame, _user, _date, _events, _selected, 2));
            }
        }

        private void RE_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null) MessageBox.Show("Please select an event first");
            else
            {
                MessageBox.Show("Selected: " + _selected._name);
                // remove from db
                _events.Remove(_selected);
                Reload();
            }
        }


        private void Reload()
        {
            Table.Children.Clear();
            posCur = 0;
            Inprint(_events);
        }
    }
}
