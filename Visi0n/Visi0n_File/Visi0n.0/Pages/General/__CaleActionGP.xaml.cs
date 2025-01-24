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
using Model_;
using VModel_;

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for __CaleActionGP.xaml
    /// </summary>
    public partial class __CaleActionGP : Page
    {
        Frame _frame;
        string _date;
        Event _target;
        ObservableCollection<Event> _collection;
        int _mode; // 1 - add; 2 - edit;
        User _user;

        public __CaleActionGP(Frame frame, User u, string date, ObservableCollection<Event> storm, Event target = null, int mode = 1)
        {
            InitializeComponent();

            _frame = frame;
            _date = date;
            _target = target;
            _collection = storm;
            _mode = mode;
            _user = u;
        }

        private void Save()
        {
            if (_mode == 1 && _target == null) //null - new
            {
                _target = new Event();
                _target._name = AcName.Text;
                _target._description = Detl.Text;
                _target._ID = EventService.CreateNewID();
                _target._date = _date;
                _target._uid = _user._absId;
            }
            else //not null - existing
            {
                if (_mode == 2)
                {
                    _target._name = AcName.Text;
                    _target._description = Detl.Text;
                }
            }
        }

        private void Saved(object sender, RoutedEventArgs e)
        {
            Save();
            _frame.Navigate(new _CaleDayViewGP(_frame, _user, _date, _collection, _target));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new _CaleDayViewGP(_frame, _user, _date, _collection));
        }
    }
}
