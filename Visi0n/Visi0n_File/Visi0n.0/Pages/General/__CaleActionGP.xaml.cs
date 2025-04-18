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
        User _user;

        public __CaleActionGP(Frame frame, User u, string date, Event target = null)
        {
            InitializeComponent();

            _frame = frame;
            _date = date;
            _target = target;
            _user = u;

            if (_target != null) { AcName.Text = _target._name; Detl.Text = _target._description; }
        }

        private void Save() => EventService.WriteEclipse(_user, _target, AcName.Text, Detl.Text, _date); // reform to simplify other ends
        /*{
            if (_target == null) // add new
            {
                _target = new Event();

                _target._name = AcName.Text;
                _target._description = Detl.Text;
                _target._ID = EventService.CreateNewID();
                _target._date = _date.Replace(" ", "");
                _target._uid = _user._absId;

                EventService.Write(_target);
            }
            else // edit selected
            {
                Event tor = _target.Copy();

                _target._name = AcName.Text;
                _target._description = Detl.Text;

                EventService.ReWrite(tor, _target);
            }
        }*/

        private void Saved(object sender, RoutedEventArgs e)
        {
            Save();
            _frame.Navigate(new _CaleDayViewGP(_frame, _user, _date));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new _CaleDayViewGP(_frame, _user, _date));
        }
    }
}
