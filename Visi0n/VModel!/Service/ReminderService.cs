using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VModel_
{
    public class ReminderService
    {
        public static List<Reminder> GetReminders(User user)
        {
            List<Reminder> l = new ReminderDB().SelectPerId(user);
            return l;
        }
    }
}
