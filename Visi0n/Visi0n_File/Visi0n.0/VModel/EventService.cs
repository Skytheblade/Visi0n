using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visi0n._0.Model;

namespace Visi0n._0.VModel
{
    public class EventService
    {
        public static ObservableCollection<Event> Load(User usr)
        {
            return new _CaleDb().SelectPerId(usr);
        }

        public static Event GetEvent(ObservableCollection<Event> l, int id)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i]._ID == id) return l[i];
            }
            return null;
        }

        public static ObservableCollection<Event> Storm(ObservableCollection<Event> l, string d)
        {
            ObservableCollection<Event> strm = new ObservableCollection<Event>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i]._date == d) strm.Add(l[i]);
            }
            return strm;
        }
    }
}
