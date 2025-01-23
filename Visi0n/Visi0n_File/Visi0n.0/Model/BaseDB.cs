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
    /// <summary>
    /// The base class for all database communication classes
    /// Uses Oledb
    /// Did not work at all on win11 os
    /// Is working with OleDb 8.0.0 & x86 or x64 (.16/.12 provider versions)
    /// </summary>
    public abstract class BaseDB
    {
        private static string dir = Directory.GetCurrentDirectory();
        private static string dirr = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(dir))); // Visi0n.0

        public string connectionString = @"" + "Provider=Microsoft.ACE.OLEDB"+".12.0" + 
            ";Data Source=" + dirr + "\\Model\\DatabaseTest1.accdb" + 
            ";Persist Security Info=True";

        public OleDbConnection connection;
        public OleDbCommand command;
        public OleDbDataReader reader;
        public System.Data.OleDb.OleDbDataReader asncReader;
        public OleDbTransaction trans;


        public BaseDB()
        {
            // setup
            this.connection = new OleDbConnection(this.connectionString);
            this.command = new OleDbCommand();
            this.command.Connection = this.connection;
        }

    }
}
