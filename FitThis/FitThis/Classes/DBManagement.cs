using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitThis
{
    public class DBManagement
    {
        /// <summary>
        /// Method to connect a database, given a connection object
        /// </summary>
        /// <param name="DB"></param>
        /// <returns></returns>
        public SQLiteConnection ConnectDB(SQLiteConnection DB)
        {
            SQLiteConnection data = new SQLiteConnection("Data Source=FitThis.sqlite");
            data.Open();
            return data;
         
        }

        /// <summary>
        /// Method to return a database.  Does the inital check to see
        /// if it exists.  If not, the db file is created, tables are set
        /// up, & test data is inserted.S
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection checkForFiles()
        {
            SQLiteConnection database = null; 
            // Check if the file exists
            if (!(File.Exists("FitThis.sqlite")))
            {
                // Creates the sql file in the bin & add in data
                SQLiteConnection.CreateFile("FitThis.sqlite");
                database = new SQLiteConnection("Data Source=FitThis.sqlite");
                database.Open();

                // Grab a file containing template database
                FileInfo file = new FileInfo("..\\..\\FitThisDB\\FitThisDB.sql");
                string sql = file.OpenText().ReadToEnd();

                // Create the tables in the file, if they don't exist.
                SQLiteCommand createTables = new SQLiteCommand(sql, database);
                createTables.ExecuteNonQuery();

            }
            else
            {
                database = new SQLiteConnection("Data Source=FitThis.sqlite");
                database.Open();
            }
          
            return database;
        }
    }
}
