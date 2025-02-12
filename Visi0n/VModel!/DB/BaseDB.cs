using Model_;
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


        protected abstract Entity EGen();
        public abstract void CreateModel(Entity e);





        protected List<Entity> Collect(string cmdTxt)
        {
            command.CommandText = cmdTxt;
            List<Entity> el = new List<Entity>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                Entity tmp = new Entity();

                while (reader.Read()) // each new reader line - each progression
                {
                    tmp = EGen();
                    CreateModel(tmp);
                    el.Add(tmp);
                }
            }
            catch (Exception ex) 
            { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); } // print error if is
            finally // close
            {
                CloseSetup();
            }

            return el;
        }

        public abstract List<Entity> SelectAll(string cmdTxt);

        //public abstract List<Entity> TargetSelect(int id, string cmdTxt);
        



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

        //protected abstract Task<int> Insert();
        //protected abstract async Task<int> Update();
        //protected abstract async Task<int> Remove();
    }
}