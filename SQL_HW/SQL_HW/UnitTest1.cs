using System;
using Xunit;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQL_HW
{
    public class UnitTest1
    {
        [Fact]
        public void Check_DepartmentByID()
        {
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Department FROM QA_Course_Students WHERE Student_ID = (SELECT Student_ID FROM Lectures WHERE Theme = 'Git' AND Activity = 10) ");
            var obj = cmd.ExecuteScalar();
            Assert.Equal("Y-Tree", (obj).ToString());
            SQL_Connection.CloseConnect(db);
        }
        [Fact]
        public void Check_FullNameByStudentID()
        {
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Full_Name FROM QA_Course_Students WHERE Student_ID = (SELECT Student_ID FROM Lectures WHERE Theme = 'SQL' AND Activity = 5) ");
            var obj = cmd.ExecuteScalar();
            Assert.Equal("Shugay Katya", obj.ToString());
            SQL_Connection.CloseConnect(db);
        }
        [Fact]
        public void Check_SoftSkillsByID()
        {
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Soft_Skills FROM QA_Course_Students WHERE Student_ID = (SELECT Student_ID FROM Lectures WHERE Theme = 'Mobile Testing' AND Activity = 6) ");
            var obj = cmd.ExecuteScalar();
            Assert.Equal(88,Convert.ToInt32(obj));
            SQL_Connection.CloseConnect(db);
        }
        [Fact]
        public void Check_StudentNameByLectureDepartment()
        {
            List<string> fullnames = new List<string>();
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Full_Name FROM QA_Course_Students WHERE Department = (SELECT Department FROM QA_Course_Lectures WHERE Full_Name = 'Bogdan Kryvko' ) ");
            SQLiteDataReader reader = cmd.ExecuteReader();  
            while (reader.Read())
            {
                fullnames.Add(reader[0].ToString());
            }
            Assert.Equal("Yarovoy Yaroslav", fullnames[0]); 
            SQL_Connection.CloseConnect(db);
        }
        [Fact]
        public void Check_StudentIDByLectureDepartment()
        {
            List<string> fullnames = new List<string>();
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Student_ID FROM QA_Course_Students WHERE Department = (SELECT Department FROM QA_Course_Lectures WHERE Full_Name = 'Bogdan Kryvko' ) ");
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fullnames.Add(reader[0].ToString());
            }
            Assert.Equal("4", fullnames[1]);
            SQL_Connection.CloseConnect(db);
        }
        [Fact]
        public void Check_LectureNameByStudentName()
        {
            List<string> fullnames = new List<string>();
            SQLiteConnection db = SQL_Connection.Connect(@"Data Source=C:/Users/hitsa/Desktop/SQL_HW/base_SQL.db");
            SQLiteCommand cmd = SQL_Connection.SQLCommand(db, "SELECT Full_Name FROM QA_Course_Lectures WHERE Lecture_ID = (SELECT Lecture_ID FROM Lectures WHERE Student_ID = (SELECT Student_ID FROM QA_Course_Students WHERE Full_Name = 'Yarovoy Yaroslav'))");
            var obj = cmd.ExecuteScalar();
            Assert.Equal("Bogdan Kryvko", obj);
            SQL_Connection.CloseConnect(db);
        }
    }
}
