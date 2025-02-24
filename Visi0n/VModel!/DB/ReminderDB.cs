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
            Reminder n = e as Reminder;
            n._uid = int.Parse(reader["Uid"].ToString());
            n._text = reader["Content"].ToString();
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

        public async Task<int> Insert(Entity e)
        {
            Reminder r;
            if (e is Reminder) r = e as Reminder;
            else return -1;
            int records = 0;

            // later fix sql injection
            string sqlStr = string.Format("INSERT INTO Reminder_Tbl (Uid, Content, Corp) " + "VALUES (" + r._uid + ", '" + r._text + "', '--');");

            return Edit(sqlStr, records).Result;
        }

        public async Task<int> Remove(Entity e)
        {
            Reminder r;
            if (e is Reminder) r = e as Reminder;
            else return -1;
            int records = 0;

            // deletes all same instances (it is now a feature)
            string sqlStr = $"DELETE FROM Reminder_Tbl WHERE (Uid = "+r._uid+" AND Content = '"+r._text+"')";

            return Edit(sqlStr, records).Result;
        }
    }
}
