using System.Data.SQLite;
using System.IO;

namespace FitThis.Classes
{
    public class SQLiteConfig
    {
        public void CreateFile()
        {
            SQLiteConnection.CreateFile("FitThis.sqlite");
        }

        /// <summary>
        /// Returns open connection
        /// </summary>
        /// <returns>SQLiteConnection to FitThis.sqlite</returns>
        public SQLiteConnection DatabaseConnection()
        {

            SQLiteConnection data = new SQLiteConnection("Data Source=FitThis.sqlite");
            data.Open();
            return data;
        }

        /// <summary>
        /// Creates a table in the database from near plain SQL Exp: CREATE TABLE highscores (name VARCHAR(20), score INT)
        /// </summary>
        /// <param name="data">The database you want to add a table to</param>
        /// <param name="sql">The string of SQL Commands</param>
        /// <returns></returns>
        public SQLiteConnection CreateTable(SQLiteConnection data, string sql)
        {
            SQLiteCommand createcommand = new SQLiteCommand(sql, data);
            createcommand.ExecuteNonQuery();
            return data;
        }


        public void InsertData(SQLiteConnection db,string table, string sql)
        {
            var cmd = new SQLiteCommand(sql,db);
            cmd.ExecuteNonQuery();
        }

    }
}