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
            UserService.MakeUser(u._usrName, u._pwd, 1);
            UserService.CreatePerson(u, p._fName, p._lName, "-");
        }
    }
}
