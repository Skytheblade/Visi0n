using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Visi0n._0.VModel;

namespace Visi0n._0.Model
{
    public class _CaleDb : BaseDB
    {
        public _CaleDb() : base() { }

        public ObservableCollection<Event> SelectPerId(User user, string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            int id = user._absId;
            command.CommandText = cmdTxt;
            ObservableCollection<Event> nl = new ObservableCollection<Event>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                Event tmp = new Event();

                while (reader.Read())
                {
                    tmp = new Event();
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

        private Event CreateModel(Event n)
        {
            n._uid = int.Parse(reader["Uid"].ToString());
            n._name = reader["EventName"].ToString();
            n._description = reader["EventContent"].ToString();
            n._date = reader["EventDate"].ToString();
            n._ID = int.Parse(reader["ID"].ToString());

            return n;
        }
    }
}
