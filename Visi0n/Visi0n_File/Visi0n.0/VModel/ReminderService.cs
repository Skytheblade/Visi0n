using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visi0n._0.Model;

namespace Visi0n._0.VModel
{
    internal class ReminderService
    {
        public static List<Reminder> GetReminders(User user)
        {
            List<Reminder> l = new _ReminderDB().SelectPerId(user);
            return l;
        }
    }
}
