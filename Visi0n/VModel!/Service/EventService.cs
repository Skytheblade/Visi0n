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

        public static ObservableCollection<Event> Storm(ObservableCollection<Event> l, string d) // an unfitting name ik, but I like it (returns all event._date == d for user)
        {
            ObservableCollection<Event> strm = new ObservableCollection<Event>();
            foreach (Event ev in l)
            {
                if (ev._date == d) strm.Add(ev);
            }
            return strm;
        }
        public static ObservableCollection<Event> Vortex(User u, string d) // the upgrade of storm; d is unspaced date
        {
            ObservableCollection<Event> events = new CaleDb().SelectPerId(u);
            ObservableCollection<Event> ell = new ObservableCollection<Event>();
            foreach (Event e in events)
            {
                if (e._date == d) ell.Add(e);
            }
            return ell;
        }

        public static int CreateNewID()
        {
            return new CaleDb().ReturnNextID();
        }

        public static Event Find(string name, User u, string date) => new CaleDb().FindEvent(name, u, date);


        public static void Tear(Event ev)
        {
            new CaleDb().Remove(ev);
        }
        public static void Write(Event ev)
        {
            new CaleDb().Insert(ev);
        }
        public static void ReWrite(Event Old, Event New)
        {
            new CaleDb().Update(Old, New);
        }
    }
}
