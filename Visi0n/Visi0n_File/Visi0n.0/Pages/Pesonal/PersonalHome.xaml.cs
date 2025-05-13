using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Visi0n._0.Pages.General;

namespace Visi0n._0.Pages.Pesonal
{
    /// <summary>
    /// Interaction logic for PersonalHome.xaml
    /// </summary>
    public partial class PersonalHome : Page
    {
        Person _person;
        Frame _frame;

        public PersonalHome(Frame frame, Person p = null)
        {
            InitializeComponent();

            _frame = frame;
            if (p != null) _person = p;

            if (_person != null) NameTitle.Content = $"Welcome {_person._fName} {_person._lName}";

            //MessageBox.Show(_person._usrName + "; " + _person._pwd + "; " + _person._absId + "; "); 
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (((Label)sender).Content.ToString())
            {
                case "Use the calendar":
                    _frame.Navigate(new CalendarGP(_frame, (User)_person));
                    break;
                case "Write notes":
                    _frame.Navigate(new NotesGP(_frame, (User)_person));
                    break;
                case "Set reminders":
                    _frame.Navigate(new RemindersGP(_frame, (User)_person));
                    break;
                default:
                    MessageBox.Show("How did you manage?");
                    break;
            }
        }
    }
}
