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


        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM   Personal_Tbl INNER JOIN (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id) ON Personal_Tbl.Uid = Usr_Tbl.ID")
        {
            return base.Collect(cmdTxt);
        }


        public override void CreateModel(Entity e)
        {
            Person p = e as Person;
            p._absId = int.Parse(reader["Uid"].ToString());

            p._usrName = reader["UserName"].ToString();
            p._pwd = reader["PassCode"].ToString();
            p._type = int.Parse(reader["Type"].ToString());

            p._fName = reader["FirstName"].ToString();
            p._lName = reader["LastName"].ToString();
            p._cid = reader["Corp"].ToString();
        }

        protected override Entity EGen()
        {
            return new Person();
        }


        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM   Personal_Tbl INNER JOIN (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id) ON Personal_Tbl.Uid = Usr_Tbl.ID")
        {
            List<Entity> cl = base.Collect(cmdTxt);
            foreach (Person p in cl) { if (p._absId == id) return p; }
            return new Person();
        }

        public override async Task<int> Insert(Entity e)
        {
            Person prsn;
            if (e is Person) prsn = e as Person;
            else return -1;

            int records = 0;

            string sqlStr = string.Format("INSERT INTO Personal_Tbl (Uid, FirstName, LastName, Corp) "
                + "VALUES (?, ?, ?, ?);");
            CommandSet(sqlStr);
            command.Parameters.AddWithValue("?", prsn._absId);
            command.Parameters.AddWithValue("?", prsn._fName);
            command.Parameters.AddWithValue("?", prsn._lName);
            command.Parameters.AddWithValue("?", prsn._cid);
            return Edit().Result;
        }
        public override async Task<int> Remove(Entity e) { return -16; } // empty
        public override async Task<int> Update(Entity e0, Entity e1) { return -16; } // empty
    }
}
