using System;
using Xunit;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQL_HW
{
    public class SQL_Connection
    {
        public static SQLiteConnection Connect (string path)
        {
            string connectionString = path;

            SQLiteConnection db = new SQLiteConnection (connectionString);
            db.Open();
            return db;
        }
        public static SQLiteCommand SQLCommand(SQLiteConnection db,string query)
        {
            SQLiteCommand cmd = db.CreateCommand();
            cmd.CommandText = query;
            return cmd;
        }
        public static void CloseConnect(SQLiteConnection db)
        {
            db.Close();
        }
    }
}
