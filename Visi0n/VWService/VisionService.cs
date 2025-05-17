using CoreWCF;
using VModel_;
using Model_;

namespace VWS
{
    public class VisionService : IVisionService
    {
        public string Status() => "Running";

        public bool Login(string Un, string Up, int T) => UserService.LoginAtt(Un, Up, T);

        public int GetID(string uName) => UserService.FindUserID(uName);

        public void CreatePerson(string cid, string fName, string lName, string un, string pd, int id = 0)
        {
            Person p = new Person(cid, fName, lName, un, pd, id);
            User u = (User)p;
            User uu = UserService.MakeUser(u._usrName, u._pwd, 1);
            UserService.CreatePerson(uu, p._fName, p._lName, "-");
        }

        public List<string> RemindersString(int id)
        {
            List<Reminder> l = Reminders(id);
            List<string> result = new List<string>();
            foreach (Reminder r in l) { result.Add(r._text); }
            return result;
        }

        public List<Reminder> Reminders(int id)
        {
            User u = UserService.Get(id);
            List<Reminder> l = ReminderService.GetReminders(u);
            return l;
        }

        public List<Event> Events(int id)
        {
            User u = UserService.Get(id);
            var ll = EventService.Load(u);
            List<Event> l = new();
            foreach (var i in ll) { l.Add(i); }
            return l;
        }

        public List<string> EventsString(int id)
        {
            var lst = Events(id);
            List<string> result = new();
            foreach (var i in lst) { result.Add(i._name); }
            return result;
        }

        public List<NoteItem> Notes(int id)
        {
            User u = UserService.Get(id);
            var ll = NoteService.GetNotes(u);
            List<NoteItem> l = new();
            foreach (var i in ll) { l.Add(i); }
            return l;
        }

        public List<string> NotesString(int id)
        {
            var lst = Notes(id);
            List<string> result = new();
            foreach (var i in lst) { result.Add(i._name); }
            return result;
        }

        public List<Person> CorpUsers(int id)
        {
            User u = UserService.Get(id);
            Corp c = UserService.Corporative(u);
            var l = UserService.LaCampanella(c);
            return l;
        }

        public List<string> CorpUsersString(int id)
        {
            var lst = CorpUsers(id);
            List<string> result = new();
            foreach(var i in lst) { result.Add($"({i._fName} {i._lName}, {i._absId})"); }
            return result;
        }
    }
}
