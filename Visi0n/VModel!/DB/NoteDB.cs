using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model_;

namespace VModel_
{
    public class NoteDB : BaseDB
    {
        public NoteDB() : base() { }

        public List<NoteItem> SelectPerId(User user, string cmdTxt = "SELECT * FROM Note_Tbl")
        {
            int id = user._absId;
            List<NoteItem> nl = new List<NoteItem>();
            List<Entity> el = base.Collect(cmdTxt);
            foreach (NoteItem n in el)
            { if (n._uid == id) nl.Add(n); }
            return nl;
        }

        public override void CreateModel(Entity e)
        {
            NoteItem n = e as NoteItem;
            n._uid = int.Parse(reader["Uid"].ToString());
            n._name = reader["NoteName"].ToString();
            n._text = reader["NoteText"].ToString();
        }

        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM Note_Tbl")
        {
            return base.Collect(cmdTxt);
        }

        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM Note_Tbl")
        {
            return new NoteItem(); // also unused
        }

        protected override Entity EGen()
        {
            return new NoteItem();
        }


        public async Task<int> Insert(Entity e)
        {
            NoteItem n;
            if (e is NoteItem) n = e as NoteItem;
            else return -1;
            int records = 0;

            string sqlStr = string.Format($"INSERT INTO Note_Tbl (Uid, NoteName, NoteText, Corp) VALUES ({n._uid}, '{n._name}', '{n._text}', '--');");

            return Edit(sqlStr, records).Result;
        }

        public async Task<int> Remove(Entity e)
        {
            NoteItem n;
            if (e is NoteItem) n = e as NoteItem;
            else return -1;
            int records = 0;

            string sqlStr = $"DELETE FROM Note_Tbl WHERE (Uid = " + n._uid + " AND NoteText = '" + n._text + "' AND NoteName = '" + n._name + "')";

            return Edit(sqlStr, records).Result;
        }

        public async Task<int> Update(Entity e0, Entity e1)
        {
            NoteItem n0; NoteItem n1;
            if (e0 is NoteItem && e1 is NoteItem) { n0 = e0 as NoteItem; n1 = e1 as NoteItem; }
            else return -1;
            int records = 0;

            string sqlStr = $"UPDATE Note_Tbl SET " +
                $" NoteName = '{n1._name}'," +
                $" NoteText = '{n1._text}' " +
                $" WHERE (Uid = {n0._uid} AND NoteText = '{n0._text}' AND NoteName = '{n0._name}')";

            return Edit(sqlStr, records).Result;
        }
    }
}
