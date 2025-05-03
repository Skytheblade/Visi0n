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
        Person _prsn;

        List<Reminder> listed;
        int ppage;

        public RemindersGP(Frame frame, User usr = null, int pagePos = 0)
        {
            InitializeComponent();
            _frame = frame;
            posCur = 0;
            ppage = pagePos;

            listed = new List<Reminder>();

            if (usr != null) { _usr = usr; _prsn = UserService.LaPersona(_usr); }
            else _usr = new User();

            Load(_usr);
            //MessageBox.Show("Listed: " + listed.Count);
        }

        public void Load(User usr)
        {
            List<Reminder> reminders = ReminderService.GetReminders(usr);
            foreach (Reminder r in reminders)
            {
                AddReminder(r); // it draws it 12 times lmao
            }
            DrawTable(listed, ppage);
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
                //if (_prsn != null) r._cid = _prsn._cid; // for testing
                ReminderService.ListReminder(r);
            }
            listed.Add(r);
            DrawTable(listed, ppage);
        }
        private void DrawR(Reminder r) // sets reminder in ui
        {
            CheckBox ck = new CheckBox() { Margin = new Thickness(4, 4, 4, 4) };
            ck.Content = r._text;
            ck.Style = (Style)FindResource("Reminder01");
            if (r._cid != "--") ck.Style = (Style)FindResource("Reminder02");
            ck.Checked += new RoutedEventHandler(CheckBox_Checked);
            Grid.SetRow(ck, posCur);
            posCur++;
            Rtable.Children.Add(ck);
        }
        private void DrawTable(List<Reminder> list, int pos) // draws 12 reminders per page
        {
            Rtable.Children.Clear(); posCur = 0;
            for(int i = pos * 12; i < (pos + 1) * 12; i++)
            {
                if (i < list.Count) DrawR(list[i]);
            }
        }

        // on: Checked=""
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Reminder r = new Reminder(_usr._absId, ((CheckBox)sender).Content.ToString());
            MessageBox.Show("To be removed: " + r._uid + " (uid), " + r._text + " (text)");
            ReminderService.DropReminder(r);
            Refresh();
        }

        private void Refresh() { _frame.Navigate(new RemindersGP(_frame, _usr, ppage)); }

        private void PosPlus_Click(object sender, RoutedEventArgs e)
        {
            ppage++; DrawTable(listed, ppage);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (ppage > 0) ppage--;
            DrawTable(listed, ppage);
        }
    }
}
