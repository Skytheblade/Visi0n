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
    public class CaleDb : BaseDB
    {
        public CaleDb() : base() { }

        public ObservableCollection<Event> SelectPerId(User user, string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            int id = user._absId;
            ObservableCollection<Event> nl = new ObservableCollection<Event>();
            List<Entity> el = SelectAll();
            foreach (Event e in el)
            { if (e._uid == id) nl.Add(e); }
            return nl;
        }

        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            return base.Collect(cmdTxt);
        }

        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            List<Entity> cl = base.Collect(cmdTxt);
            foreach (Event e in cl)
            { if (e._ID == id) return e; }
            return new Event();
        }

        public override void CreateModel(Entity e)
        {
            Event n = e as Event;
            n._uid = int.Parse(reader["Uid"].ToString());
            n._name = reader["EventName"].ToString();
            n._description = reader["EventContent"].ToString();
            n._date = reader["EventDate"].ToString();
            n._ID = int.Parse(reader["ID"].ToString());
            n._cid = reader["Corp"].ToString();
        }

        protected override Entity EGen()
        {
            return new Event();
        }


        public int ReturnNextID(string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            command.CommandText = cmdTxt;
            int nMax = 0;

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nMax++;
                }

                nMax++;
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); }
            finally
            {
                CloseSetup();
            }
            return nMax;
        }

        public int FindID(string ename, User u, string date)
        {
            List<Entity> el = SelectAll();
            int found = -1;
            foreach (Event e in el)
            {
                if (u._absId == e._uid && ename == e._name && date == e._date) found = e._ID;
            }
            return found; // -1 return as not found
        }
        public Event FindEvent(string ename, User u, string date)
        {
            List<Entity> el = SelectAll(); int id = FindID(ename, u, date); Event eve = new Event();
            foreach (Event e in el) { if (e._ID == id) eve = e; }
            return eve; // empty event return (_ID = -1, _uid = -1) as not found
        }


        public override async Task<int> Insert(Entity e)
        {
            Event n;
            if (e is Event) n = e as Event;
            else return -1;
            int records = 0;

            string sqlStr = string.Format($"INSERT INTO Cale_Tbl (Uid, EventName, EventContent, EventDate, Corp) VALUES ({n._uid}, '{n._name}', '{n._description}', '{n._date}', '{n._cid}');");

            return Edit(sqlStr, records).Result;
        }

        public override async Task<int> Remove(Entity e)
        {
            Event n;
            if (e is Event) n = e as Event;
            else return -1;
            int records = 0;

            string sqlStr = $"DELETE FROM Cale_Tbl WHERE (Uid = {n._uid} AND EventContent = '{n._description}' AND EventName = '{n._name}' AND EventDate = '{n._date}')";

            return Edit(sqlStr, records).Result;
        }

        public override async Task<int> Update(Entity e0, Entity e1)
        {
            Event n0; // old
            Event n1; // new
            if (e0 is Event && e1 is Event) { n0 = e0 as Event; n1 = e1 as Event; }
            else return -1;
            int records = 0;

            string sqlStr = $"UPDATE Cale_Tbl SET " +
                $" EventName = '{n1._name}'," +
                $" EventContent = '{n1._description}' " +
                $" WHERE (Uid = {n0._uid} AND EventContent = '{n0._description}' AND EventName = '{n0._name}' AND EventDate = '{n0._date}')";

            return Edit(sqlStr, records).Result;
        }

        public List<string> DaysActive(int id, string month, string year, int t = 0)
        {
            List<string> ll = new List<string>();
            foreach(Event l in SelectAll())
            {
                if (l._uid == id)
                {
                    if (t == 0)
                    {
                        if (l._date.Split("/")[1] == month.ToString() && l._date.Split("/")[2] == year.ToString())
                        {
                            ll.Add(l._date.Split("/")[0]);
                        }
                    }
                    else
                    {
                        if (l._date.Split("/")[1] == month.ToString() && l._date.Split("/")[2] == year.ToString() && (l._cid != "--" && l._cid != "0"))
                        {
                            ll.Add(l._date.Split("/")[0]);
                        }
                    }
                }
            }
            return ll;
        }
    }
}
