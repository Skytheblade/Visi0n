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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public _CaleDayViewGP(Frame frame, User u, string date, Event edited = null)
        {
            InitializeComponent();

            _frame = frame;
            _date = date;
            _user = u;
            _events = EventService.Vortex(_user, Date());
            
            
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

            DateStringLabel.Content = _date;

            Inprint(_events);
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new CalendarGP(_frame, _user));
        }


        public void Inprint(ObservableCollection<Event> evs)
        {
            foreach (Event e in evs) { AddItem(e); }
        }
        private void AddItem(Event ev)
        {
            Label label = new Label() { Content = ev._name, Margin = new Thickness(5, 5, 5, 5) };
            label.Style = (Style)FindResource("Note01");
            Grid.SetRow(label, posCur);
            label.MouseDown += new MouseButtonEventHandler(label_MouseDown);
            Table.Children.Add(label);
            posCur++;
        }

        private string Date() => _date.Replace(" ", ""); // unspaced version - as in the database


        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string name = ((Label)sender).Content.ToString();
            _selected = EventService.Find(name, _user, Date());

            if (_selected != null) MessageBox.Show(_selected._ID + "\n" + _selected._name + "\n" + _selected._description + "\n" + _selected._date + "\n" + _selected._uid);
            else MessageBox.Show("Error - event not found");
        }


        private void AD_Click(object sender, RoutedEventArgs e)
        {
            if (_selected != null) MessageBox.Show("Selected: " + _selected._name);
            _frame.Navigate(new __CaleActionGP(_frame, _user, _date));
        }

        private void ED_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null) MessageBox.Show("Please select an event first");
            else
            {
                MessageBox.Show("Selected: " + _selected._name);
                _frame.Navigate(new __CaleActionGP(_frame, _user, _date, _selected));
            }
        }

        private void RE_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null) MessageBox.Show("Please select an event first");
            else
            {
                MessageBox.Show("Selected to be removed: " + _selected._name);
                EventService.Tear(_selected);
                //_events.Remove(_selected);
                Reload();
            }
        }


        /*private void ForceReload()
        {
            Table.Children.Clear();
            posCur = 0;
            Inprint(_events);
        }*/

        private void Reload()
        {
            _frame.Navigate(new _CaleDayViewGP(_frame, _user, _date));
        }
    }
}
