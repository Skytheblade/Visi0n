using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Visi0n._0.VModel;

namespace Visi0n._0.Model
{
    public class _ReminderDB : BaseDB
    {
        public _ReminderDB() : base() { }

        public List<Reminder> SelectPerId(User user, string cmdTxt = "SELECT * FROM Reminder_Tbl")
        {
            int id = user._absId;
            command.CommandText = cmdTxt;
            List<Reminder> nl = new List<Reminder>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                Reminder tmp = new Reminder();

                while (reader.Read())
                {
                    tmp = new Reminder();
                    tmp = CreateModel(tmp);
                    if (user._absId == tmp._uid) nl.Add(tmp);
                }
            }
            catch (Exception ex) { MessageBox.Show(" Could not load database \n Error message: \n " + ex.Message); }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return nl;
        }

        private Reminder CreateModel(Reminder n)
        {
            n._uid = int.Parse(reader["Uid"].ToString());
            n._text = reader["Content"].ToString();

            return n;
        }
    }
}
