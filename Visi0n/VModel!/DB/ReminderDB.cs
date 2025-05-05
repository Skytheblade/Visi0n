using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model_;

namespace VModel_
{
    public class ReminderDB : BaseDB
    {
        public ReminderDB() : base() { }


        public List<Reminder> SelectPerId(User user, string cmdTxt = "SELECT * FROM Reminder_Tbl")
        {
            int id = user._absId;
            List<Reminder> rl = new List<Reminder>();
            List<Entity> el = base.Collect(cmdTxt);
            foreach (Reminder r in el)
            { if (r._uid == id) rl.Add(r); }
            return rl;
        }

        public override void CreateModel(Entity e)
        {
            Reminder r = e as Reminder;
            r._uid = int.Parse(reader["Uid"].ToString());
            r._text = reader["Content"].ToString();
            r._cid = reader["Corp"].ToString();
        }

        protected override Entity EGen()
        {
            return new Reminder();
        }

        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM Reminder_Tbl")
        {
            return base.Collect(cmdTxt);
        }

        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM Reminder_Tbl")
        {
            return new Reminder(); // unused
        }

        public override async Task<int> Insert(Entity e)
        {
            Reminder r;
            if (e is Reminder) r = e as Reminder;
            else return -1;
            int records = 0;

            // later fix sql injection (fixed)
            string sqlStr = string.Format("INSERT INTO Reminder_Tbl (Uid, Content, Corp) " + "VALUES (?, ?, ?);");
            CommandSet(sqlStr);
            command.Parameters.AddWithValue("?", r._uid);
            command.Parameters.AddWithValue("?", r._text);
            command.Parameters.AddWithValue("?", r._cid);
            return Edit().Result;
        }

        public override async Task<int> Remove(Entity e)
        {
            Reminder r;
            if (e is Reminder) r = e as Reminder;
            else return -1;
            int records = 0;

            // deletes all same instances (it is now a feature)
            string sqlStr = $"DELETE FROM Reminder_Tbl WHERE (Uid = ? AND Content = ?)";
            CommandSet(sqlStr);
            command.Parameters.AddWithValue("?", r._uid);
            command.Parameters.AddWithValue("?", r._text);
            return Edit().Result;
        }

        public override async Task<int> Update(Entity e0, Entity e1) { return -16; } // empty
    }
}
