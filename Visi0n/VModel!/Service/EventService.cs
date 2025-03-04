using Model_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VModel_
{
    public class EventService
    {
        public static ObservableCollection<Event> Load(User usr)
        {
            return new CaleDb().SelectPerId(usr);
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
            foreach (Event ev in l)
            {
                if (ev._date == d) strm.Add(ev);
            }
            return strm;
        }

        public static int CreateNewID()
        {
            return new CaleDb().ReturnNextID();
        }

        public static int FindId(string name, User u, string date)
        {
            return new CaleDb().FindID(name, u, date);
        }
    }
}
