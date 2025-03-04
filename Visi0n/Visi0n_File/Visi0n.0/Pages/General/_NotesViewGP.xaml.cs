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
    /// Interaction logic for _NotesViewGP.xaml
    /// </summary>
    public partial class _NotesViewGP : Page
    {
        Frame _frame;
        User _user;
        NoteItem _item;
        int _type;

        public _NotesViewGP(Frame frame, User usr, NoteItem n)
        {
            InitializeComponent();
            _frame = frame;
            _user = usr;
            _item = n;

            Render(_item);
            //MessageBox.Show("" + _user._absId);
        }

        private void Render(NoteItem n)
        {
            Name_.Text = n._name;
            Text_.Text = n._text;
            //MessageBox.Show($"Uid: {n._uid}");
        }


        private void SetBack()
        {
            _frame.Navigate(new NotesGP(_frame, _user));
        }

        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            SetBack();
        }

        private void saveB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Will be saved: ({_item._uid}, {_item._name }, {_item._text }) :(uid, name, text)");
            if (_item._uid > 0)
            {
                NoteService.UpdateNote(_item, Name_.Text, Text_.Text);
            }
            else
            {
                _item._uid = _user._absId;
                _item._name = Name_.Text;
                _item._text = Text_.Text;
                NoteService.WriteNote(_item);
            }
            SetBack();
        }

        private void deleteB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Will be deleted: ({_item._uid}, {_item._name}, {_item._text}) :(uid, name, text)");
            NoteService.DeleteNote(new NoteItem(_item._name, _item._text, _item._uid));
            SetBack();
        }
    }
}
