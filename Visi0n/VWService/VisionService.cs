using CoreWCF;
using VModel_;
using Model_;

namespace VWS
{
    public class VisionService : IVisionService
    {
        public string Status() => "Running";

        public bool Login(string Un, string Up, int T) => UserService.LoginAtt(Un, Up, T);

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
    }
}
