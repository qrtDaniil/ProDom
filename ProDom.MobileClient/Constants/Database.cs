using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Constants
{
    public class Database
    {
        public const string DB_NAME = "SmartYardDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DB_NAME);

        // table Messages constants

       

        //table Polls constants




    }
}
