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
        }

        private void Render(NoteItem n)
        {
            Name_.Text = n._name;
            Text_.Text = n._text;
            MessageBox.Show($"Uid: {n._uid}");
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
            MessageBox.Show($"Will be updated: ({_item._uid}, {_item._name }, {_item._text }) :(uid, name, text)");
            NoteService.UpdateNote(_item, Name_.Text, Text_.Text);
            SetBack();
        }

        private void deleteB_Click(object sender, RoutedEventArgs e)
        {
            //
            SetBack();
        }
    }
}
