using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visi0n._0.Model
{
    // working with OleDb 8.0.0 & x86
    public abstract class BaseDB
    {
        //private static string dir = Directory.GetCurrentDirectory(); // dir = ...\Nous.x\Nous\bin\Debug\net6.0-windows (target directory is Nous)
        //private static string dirr = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(dir)));

        public string connectionString = @"" + "Provider=Microsoft.ACE.OLEDB.12.0" + ";Data Source=" + "C:\\Users\\User\\Desktop\\Visi0n\\Visi0n\\Visi0n_File\\Visi0n.0\\Model\\DatabaseTest1.accdb" +
            //dirr + "\\Database2.accdb" + // Data Source= ...\\***\\***\\Nous.x\\Nous\\Database1.accdb
            ";Persist Security Info=True";

        public OleDbConnection connection;
        public OleDbCommand command;
        public OleDbDataReader reader;
        public System.Data.Common.DbDataReader asncReader;
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
