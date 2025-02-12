using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model_;

namespace VModel_
{
    public class UserService
    {
        public static bool LoginAtt(string usrname, string pass, int type_)
        {
            UserDB usrdb = new UserDB();
            User usr = usrdb.TargetSelect(new UserDB().FindID(usrname));

            if (usr._usrName == usrname && usr._pwd == pass && (usr._type == type_ || usr._type == 3)) return true;
            return false;
            //return true;
        }

        public static User Get(int id = 2)
        {
            UserDB usrdb = new UserDB();
            User usr = usrdb.TargetSelect(id);
            if (usr._absId == id) return usr;
            else return null;
            //return new User("Name0", "Pass0", id);
        }

        public static User MakeUser(string usrN, string pass, int ty)
        {
            User uu = new User(usrN, pass, NextId(), ty);

            new UserDB().Insert(uu);

            return uu;
        }

        public static int NextId()
        {
            List<Entity> ul = new UserDB().Collect();
            int iid = 0;
            foreach (User u in ul/*int i = 0; i < ul.Count; i++*/)
            {
                if (iid <= u._absId) iid = u._absId;
            }
            iid++;
            return iid;
        }
    }
}
