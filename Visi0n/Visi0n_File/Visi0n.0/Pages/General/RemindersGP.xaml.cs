using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            foreach (Reminder r in reminders)
            {
                AddReminder(r);
            }
        }

        private void AddRCommand(object sender, RoutedEventArgs e)
        {
            AddReminder();
        }
        private void AddReminder(Reminder r = null)
        {
            if (r == null) 
            { 
                r = new Reminder(_usr._absId, TextName.Text);
                ReminderService.ListReminder(r);
            }
            DrawR(r);
        }
        private void DrawR(Reminder r)
        {
            CheckBox ck = new CheckBox() { Margin = new Thickness(4, 4, 4, 4) };
            ck.Content = r._text;
            ck.Style = (Style)FindResource("Reminder01");
            ck.Checked += new RoutedEventHandler(CheckBox_Checked);
            Grid.SetRow(ck, posCur);
            posCur++;
            Rtable.Children.Add(ck);
        }

        // on: Checked=""
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Reminder r = new Reminder(_usr._absId, ((CheckBox)sender).Content.ToString());
            MessageBox.Show("To be removed: " + r._uid + " (uid), " + r._text + " (text)");
            ReminderService.DropReminder(r);
        }
    }
}
