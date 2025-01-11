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
using Visi0n._0.VModel;

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for RemindersGP.xaml
    /// </summary>
    public partial class RemindersGP : Page
    {
        Frame _frame;
        int posCur;

        User _usr;

        public RemindersGP(Frame frame, User usr = null)
        {
            InitializeComponent();
            _frame = frame;
            posCur = 0;

            if (usr != null) _usr = usr;
            else _usr = new User();

            Load(_usr);
        }

        public void Load(User usr)
        {
            List<Reminder> reminders = ReminderService.GetReminders(usr);
            for (int i = 0; i < reminders.Count; i++)
            {
                AddReminder(reminders.First());
                reminders.RemoveAt(0);
            }
        }

        private void AddRCommand(object sender, RoutedEventArgs e)
        {
            AddReminder();
        }
        private void AddReminder(Reminder r = null)
        {
            CheckBox ck = new CheckBox() { Margin = new Thickness(4, 4, 4, 4) };
            if (r != null)
                ck.Content = r._text;
            else
                ck.Content = TextName.Text;
            ck.Style = (Style)FindResource("Reminder01");
            Grid.SetRow(ck, posCur);
            posCur++;
            Rtable.Children.Add(ck);
        }

        // on: Checked=""
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // remove
        }
    }
}
