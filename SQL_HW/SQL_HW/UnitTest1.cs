using System;
using Xunit;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQL_HW
{
    public class UnitTest1
    {
        List<string> studentName = new List<string>();
        List<string> companyName = new List<string>();
        List<string> softSkills = new List<string>();
        List<string> hardSkills = new List<string>();

        [Fact]
        public void Test1()
        {
            List<string> fullnames = new List<string>();
            List<int> user_id = new List<int>();
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "Select * FROM Persons");
            //var obj = cmd.ExecuteScaler();
            SQLiteDataReader reader = cmd.ExecuteReader();
            //заполняем списки датой
            while (reader.Read())
            {
                fullnames.Add(reader[0].ToString());
                user_id.Add(Convert.ToInt32(reader[1]));
            }
            //вывод инфы в консоль
            foreach (string a in fullnames)
            {
                Console.WriteLine(a);
            }
            foreach (int a in user_id)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }
    }
}
