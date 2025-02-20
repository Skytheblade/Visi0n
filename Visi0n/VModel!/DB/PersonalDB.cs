using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VModel_
{
    public class PersonalDB : BaseDB
    {
        public PersonalDB() : base() { }


        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM Personal_Tbl")
        {
            return base.Collect(cmdTxt);
        }


        public override void CreateModel(Entity e)
        {
            Person p = e as Person;
            p._absId = int.Parse(reader["ID"].ToString());

            User u = (User)(new UserDB().TargetSelect(p._absId)); // !
            p._usrName = u._usrName;
            p._pwd = u._pwd;
            p._type = 1;

            p._fName = reader["FirstName"].ToString();
            p._lName = reader["LastName"].ToString();
            p._cid = reader["Corp"].ToString();
        }

        protected override Entity EGen()
        {
            return new Person();
        }


        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM Personal_Tbl")
        {
            List<Entity> cl = base.Collect(cmdTxt);
            foreach (Person p in cl) { if (p._absId == id) return p; }
            return new Person();
        }
    }
}
