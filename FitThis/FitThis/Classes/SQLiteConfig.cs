using System.CodeDom.Compiler;
using System.Data.SQLite;
using System.IO;

namespace FitThis
{
    public class SQLiteConfig
    {
   
        /// <summary>
        /// TODO -- See methods in DB Management class
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


        public void InsertUpdateDeleteData(SQLiteConnection db, string sql)
        {
            int xyz = 1;
           //SQLiteCommand createTables = new SQLiteCommand(sql, database);
            //createTables.ExecuteNonQuery();

            SQLiteCommand cmd = new SQLiteCommand(sql,db);
            cmd.ExecuteNonQuery();
        }

        public SQLiteDataReader SelectData(SQLiteConnection db, string sql)
        {
            var cmd = new SQLiteCommand(sql, db);
            return cmd.ExecuteReader();
        }
    }
}