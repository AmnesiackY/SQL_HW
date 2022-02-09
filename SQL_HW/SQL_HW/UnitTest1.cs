using System;
using Xunit;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQL_HW
{
    public class UnitTest1
    {
        List<string> department = new List<string>();
        List<string> user_id = new List<string>();

        [Fact]
        public void Test1()
        {
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Department FROM QA_Course_Students WHERE Student_ID = (SELECT Student_ID FROM Lectures WHERE Theme = 'Git' AND Activity = 10) ");
            var obj = cmd.ExecuteScalar();
            Assert.Equal("Y-Tree", (obj).ToString());
            SQL_Connection.CloseConnect(db);
        }
        [Fact]
        public void Test2()
        {
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Full_Name FROM QA_Course_Students WHERE Student_ID = (SELECT Student_ID FROM Lectures WHERE Theme = 'SQL' AND Activity = 5) ");
            var obj = cmd.ExecuteScalar();
            Assert.Equal("Shugay Katya", obj.ToString());
            SQL_Connection.CloseConnect(db);
        }
        [Fact]
        public void Test3()
        {
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Soft_Skills FROM QA_Course_Students WHERE Student_ID = (SELECT Student_ID FROM Lectures WHERE Theme = 'Mobile Testing' AND Activity = 6) ");
            var obj = cmd.ExecuteScalar();
            Assert.Equal(88,Convert.ToInt32(obj));
            SQL_Connection.CloseConnect(db);
        }

    }
}
