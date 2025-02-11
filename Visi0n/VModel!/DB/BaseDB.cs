using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace VModel_
{
    /// <summary>
    /// The base class for all database communication classes
    /// Is working with OleDb 8.0.0 & x86 or x64 (.16/.12 provider versions)
    /// </summary>
    public abstract class BaseDB
    {
        private static string dir = Directory.GetCurrentDirectory();
        private static string dirr = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(dir)))));

        public string connectionString = @"" + "Provider=Microsoft.ACE.OLEDB" + ".12.0" +
            ";Data Source=" + dirr + "\\VModel!\\DB\\DatabaseTest1.accdb" +
            ";Persist Security Info=True";

        public OleDbConnection connection;
        public OleDbCommand command;
        public OleDbDataReader reader;
        public System.Data.OleDb.OleDbDataReader asncReader;
        public OleDbTransaction trans;


        protected BaseDB()
        {
            // setup
            this.connection = new OleDbConnection(this.connectionString);
            this.command = new OleDbCommand();
            this.command.Connection = this.connection;
        }

        protected void CloseSetup()
        {
            if (reader != null) reader.Close();
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }


        /*public List<T> Collect<T>(string cmdTxt /* = "SELECT * FROM Usr_Tbl")
        {
            command.CommandText = cmdTxt;
            List<T> ul = new List<T>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                T tmp = new T();

                while (reader.Read()) // each new reader line - each progression
                {
                    tmp = new T();
                    tmp = CreateModel(tmp);
                    ul.Add(tmp);
                }
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); } // print error if is

            finally { CloseSetup(); }
            return ul;
        }*/


        protected async Task<int> Edit(string sqlStr, int records = 0)
        {
            trans = null;
            try
            {
                command.CommandText = sqlStr;
                connection.Open();
                trans = connection.BeginTransaction();
                command.Transaction = trans;
                records = command.ExecuteNonQuery(); // action; + Async & await for later
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                Console.WriteLine("Error message: \n " + e.Message);
            }
            finally
            {
                CloseSetup();
            }
            return records;
        }

        //protected abstract async Task<int> Insert();
        //protected abstract async Task<int> Update();
        //protected abstract async Task<int> Remove();
    }
}