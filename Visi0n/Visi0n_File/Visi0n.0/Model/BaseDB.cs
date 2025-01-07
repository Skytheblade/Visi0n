using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Visi0n._0.Model
{
    // did not work at all on win11 os
    // working with OleDb 8.0.0 & x86 or x64 (.16/.12 provider versions)
    public abstract class BaseDB
    {
        private static string dir = Directory.GetCurrentDirectory();
        private static string dirr = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(dir))); // Visi0n.0

        public string connectionString = @"" + "Provider=Microsoft.ACE.OLEDB"+".16.0" + ";Data Source=" + //"C:\\Users\\User\\Desktop\\Visi0n\\Visi0n\\Visi0n_File\\Visi0n.0\\Model\\DatabaseTest1.accdb" +
            dirr + "\\Model\\DatabaseTest1.accdb" + 
            ";Persist Security Info=True";

        //public string connectionString = @"" + "Data Source=" + "C:\\Users\\User\\Desktop\\Visi0n\\Visi0n\\Visi0n_File\\Visi0n.0\\Model\\DatabaseTest1.accdb" /*+ ";Version=3"*/;

        public OleDbConnection connection;
        public OleDbCommand command;
        public OleDbDataReader reader;
        public System.Data.OleDb.OleDbDataReader asncReader;
        public OleDbTransaction trans;

        //public string uidNext { get; protected set; }
        //protected int[] uidArr;


        public BaseDB()
        {
            
            this.connection = new OleDbConnection(this.connectionString);
            this.command = new OleDbCommand();
            this.command.Connection = this.connection;
        }

        /*protected BaseEntity CreateModel(BaseEntity entity)
        {
            if (asncReader != null) entity.id = asncReader["UID"].ToString();
            return entity;
        }
        protected abstract int[] ArchRun();*/
    }
}
