using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using Visi0n._0.Pages.General;

namespace Visi0n._0
{
    /// <summary>
    /// Interaction logic for Menu001.xaml
    /// </summary>
    public partial class Menu001 : UserControl
    {
        User _user;
        Frame _frame;
        int _type;

        public Menu001(Frame f, User u, int t = 0)
        {
            InitializeComponent();
            this.DataContext = this;
            _user = u;
            _type = t;
            _frame = f;

            switch (_type)
            {
                case 1:
                    ActB.Content = "Calendar"; break;
                case 2:
                    ActB.Content = "Notes"; break;
                default:
                    ActB.Content = "Reminders"; break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (_type)
            {
                case 1:
                    {
                        _frame.Navigate(new CalendarGP(_frame, _user));
                        break;
                    }
                case 2:
                    {
                        _frame.Navigate(new NotesGP(_frame, _user));
                        break;
                    }
                default:
                    {
                        _frame.Navigate(new RemindersGP(_frame, _user));
                        break;
                    }
            }
        }
    }
}
