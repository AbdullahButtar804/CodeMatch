using CodeMatch.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeMatch.Helpers
{
    public class DatabaseHelper
    {
        
    private static string dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydb.sqlite");
    private static SQLiteConnection connection;

    public static void CreateDatabase()
    {
        connection = new SQLiteConnection(dbFile);
            connection.DeleteAll<NetworkCodeModel>();

            connection.CreateTable<NetworkCodeModel>();
    }

    public static void InsertData(string code, string networkName ,string name)
    {
        connection.Insert(new NetworkCodeModel { code = code, networkName = networkName ,name=name});
    }

    public static string GetStoredCode()
    {
        return connection.Table<NetworkCodeModel>().FirstOrDefault()?.code;
    }

    public static string GetStoredNetworkName()
    {
        return connection.Table<NetworkCodeModel>().FirstOrDefault()?.networkName;
    }
     public static string GetStoredUserName()
    {
        return connection.Table<NetworkCodeModel>().FirstOrDefault()?.name;
    }
     

    }
}
