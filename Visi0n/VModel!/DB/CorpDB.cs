using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VModel_
{
    public class CorpDB : BaseDB
    {
        /*
         SELECT * FROM   (T1 INNER JOIN T2 ON T2.C = T1.C) INNER JOIN (T3 LEFT JOIN T4 ON T4.C = T3.C) ON T3.C = T2.C 
         SELECT * FROM   Corp_Tbl INNER JOIN (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id) ON Corp_Tbl.Uid = Usr_Tbl.ID
        */

        public CorpDB() : base() { }


        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM   Corp_Tbl INNER JOIN (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id) ON Corp_Tbl.Uid = Usr_Tbl.ID")
        {
            return base.Collect(cmdTxt);
            //"SELECT * FROM Corp_Tbl"
        }


        public override void CreateModel(Entity e)
        {
            Corp c = e as Corp;
            c._absId = int.Parse(reader["Uid"].ToString());

            /*User u = (User)(new UserDB().TargetSelect(c._absId));
            c._usrName = u._usrName;
            c._pwd = u._pwd;
            c._type = 2;*/

            c._usrName = reader["UserName"].ToString();
            c._pwd = reader["PassCode"].ToString();
            c._type = int.Parse(reader["Type"].ToString());


            c._cid = reader["Cid"].ToString();
            c._cName = reader["CorpName"].ToString();
        }

        protected override Entity EGen()
        {
            return new Corp();
        }


        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM   Corp_Tbl INNER JOIN (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id) ON Corp_Tbl.Uid = Usr_Tbl.ID")
        {
            List<Entity> cl = base.Collect(cmdTxt);
            foreach (Corp c in cl) { if (c._absId == id) return c; }
            return new Corp();
        }

        public Corp Call(string id, string cmdTxt = "SELECT * FROM   Corp_Tbl INNER JOIN (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id) ON Corp_Tbl.Uid = Usr_Tbl.ID")
        {
            List<Entity> cl = base.Collect(cmdTxt);
            foreach (Corp c in cl) { if (c._cid == id) return c; }
            return new Corp();
        }

        public override async Task<int> Insert(Entity e) { return -16; } // empty
        public override async Task<int> Remove(Entity e) { return -16; } // empty
        public override async Task<int> Update(Entity e0, Entity e1) { return -16; } // empty
    }
}
