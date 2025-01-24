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

        public _NotesViewGP(Frame frame, User usr, int type)
        {
            InitializeComponent();
            _frame = frame;
            _user = usr;
            _type = type;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_type == 0) { _frame.Navigate(new NotesGP(_frame, new NoteItem(Name.Text, Text.Text, _user._absId), _user)); }
            else { _frame.Navigate(new NotesGP(_frame, null, _user)); }
        }
    }
}
