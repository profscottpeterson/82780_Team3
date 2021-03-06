﻿using System;
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
        

        SQLiteConnection db = new SQLiteConnection();
        /// <summary>
        /// Method to connect a database, given a connection object
        /// </summary>
        /// <param name="DB"></param>
        /// <returns></returns>
        public SQLiteConnection ConnectDB(SQLiteConnection DB)
        {
            SQLiteConnection data = new SQLiteConnection("Data Source=FitThis.sqlite");
            db = data;
            return data;
         
        }

        /// <summary>
        /// Method to return a database.  Does the inital check to see
        /// if it exists.  If not, the db file is created, tables are set
        /// up, & test data is inserted.S
        /// </summary>
        /// <returns></returns>
        public void checkForFiles()
        {
            bool verdict = false;
            SQLiteConnection database = null; 
            // Check if the file exists
            if (!(File.Exists("FitThis.sqlite")))
            {
                // Creates the sql file in the bin & add in data
                SQLiteConnection.CreateFile("FitThis.sqlite");
                database = new SQLiteConnection("Data Source=FitThis.sqlite");

                // Grab a file containing template database
                FileInfo file = new FileInfo("..\\..\\FitThisDB\\FitThisDB.sql");
                string sql = file.OpenText().ReadToEnd();

                // Create the tables in the file, if they don't exist.
                ExecuteNonQuery(sql, database);

            }
        }

        public void ExecuteNonQuery(string queryString, SQLiteConnection db)
        {
            using (db)
            {
                using (SQLiteCommand command = new SQLiteCommand(queryString, db))
                {
                    if (db.State == System.Data.ConnectionState.Closed)
                    {
                        db.Open();
                    }

                    command.ExecuteNonQuery();
                }
            }


        }

        public SQLiteDataReader ExecuteReader(string queryString, SQLiteConnection db)
        {
            using (db)
            {
                using (SQLiteCommand command = new SQLiteCommand(queryString, db))
                {
                    if (db.State == System.Data.ConnectionState.Closed)
                    {
                        db.Open();
                    }

                    return command.ExecuteReader();
                }
            }


        }

        public SQLiteDataReader DatabaseReader(string queryString)
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(queryString, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        return reader;  
                    }
                }
            }
        }

        public void DatabasCommand(string queryString)
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(queryString, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
