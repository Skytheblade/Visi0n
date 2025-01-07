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

namespace Visi0n._0.Pages.Pesonal
{
    /// <summary>
    /// Interaction logic for PersonalHome.xaml
    /// </summary>
    public partial class PersonalHome : Page
    {
        User _user;

        public PersonalHome(User user = null)
        {
            InitializeComponent();
        }
    }
}
