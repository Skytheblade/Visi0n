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
using Visi0n._0.Pages.Pesonal;
using Model_;
using VModel_;

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for NotesGP.xaml
    /// </summary>
    public partial class NotesGP : Page
    {
        Frame _frame;
        NoteItem _note;
        int posCur;

        User _usr;

        public NotesGP(Frame frame, NoteItem nt = null, User usr = null)
        {
            InitializeComponent();
            _frame = frame;
            _note = nt;

            posCur = 0;
            if (nt != null) { AddItem(nt); }

            if (usr != null) { _usr = usr; }
            else { _usr = new User(); }

            SetNotes(_usr);

        }

        public void SetNotes(User usr)
        {
            List<NoteItem> notes = NoteService.GetNotes(usr);
            for (int i = 0; i < notes.Count; i++)
            {
                AddItem(notes.First());
                notes.RemoveAt(0);
            }
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new _NotesViewGP(_frame, _usr, 0));
        }

        private void AddItem(NoteItem nt)
        {
            Label label = new Label() { Content = nt._name, Margin = new Thickness(5, 5, 5, 5) };
            label.Style = (Style)FindResource("Note01");
            Grid.SetRow(label, posCur);
            label.MouseDown += new MouseButtonEventHandler(label_MouseDown);
            Table.Children.Add(label);
            posCur++;
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new _NotesViewGP(_frame, _usr, 1));
        }
    }
}
