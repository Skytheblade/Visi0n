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

        List<NoteItem> _notes;
        int pagePos;

        public NotesGP(Frame frame, User usr = null, int pagePos = 0)
        {
            InitializeComponent();
            _frame = frame;

            posCur = 0;
            _notes = new List<NoteItem>();

            if (usr != null) { _usr = usr; }
            else { _usr = new User(); }
            //MessageBox.Show($"UID = {_usr._absId}");

            this.pagePos = pagePos;

            SetNotes(_usr);
            
        }

        public void SetNotes(User usr)
        {
            List<NoteItem> notes = NoteService.GetNotes(usr);
            foreach (NoteItem n in notes)
            {
                _notes.Add(n);
            }
            DrawTable(_notes, pagePos);
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new _NotesViewGP(_frame, _usr, new NoteItem()));
        }

        private void AddItem(NoteItem nt)
        {
            Label label = new Label() { Content = nt._name, Margin = new Thickness(5, 5, 5, 5) };
            label.Style = (Style)FindResource("Note01");
            if (nt._cid != "--") label.Style = (Style)FindResource("Note02");
            Grid.SetRow(label, posCur);
            label.MouseDown += new MouseButtonEventHandler(label_MouseDown);
            Table.Children.Add(label);
            posCur++;
            
        }

        private void DrawTable(List<NoteItem> list, int pos)
        {
            Table.Children.Clear(); posCur = 0;
            for (int i = pos * 8; i < (pos + 1) * 8; i++)
            {
                if (i < list.Count) AddItem(list[i]);
            }
        }


        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NoteItem nt = NoteService.Find(_usr, ((Label)sender).Content.ToString());
            if (nt._uid == -1) MessageBox.Show("Note not found - an error occured");
            else
            {
                MessageBox.Show($"Selected: Uid = {nt._uid}, Name = {nt._name}");
                _frame.Navigate(new _NotesViewGP(_frame, _usr, nt));
            }
        }

        private void PosMinus_Click(object sender, RoutedEventArgs e)
        {
            if (pagePos > 0) { pagePos--; } DrawTable(_notes, pagePos);
        }

        private void PosPlus_Click(object sender, RoutedEventArgs e)
        {
            pagePos++; DrawTable(_notes, pagePos);
        }
    }
}
