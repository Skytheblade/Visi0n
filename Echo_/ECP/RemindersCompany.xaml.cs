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

namespace Visi0n._0.Pages.Company
{
    /// <summary>
    /// Interaction logic for RemindersCompany.xaml
    /// </summary>
    public partial class RemindersCompany : Page
    {

        Frame _frame;

        public RemindersCompany(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
    }
}
