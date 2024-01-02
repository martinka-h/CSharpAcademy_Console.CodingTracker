﻿using System.Globalization;
using Microsoft.Data.Sqlite;
using CodingTracker;

class Program
{
    static string connectionString = @"Data Source = codingtracker.db";

    static void Main(string[] args)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS coding_sessions (
                Id INTEGER PRIMARY KEY,
                StartDateTime TEXT,
                EndDateTime TEXT
                Duration REAL)";

            tableCmd.ExecuteNonQuery();
            connection.Close();
        }

        MainMenu();
    }

    static void MainMenu()
    {
        Console.Clear();
        bool closeApp = false;
        while (!closeApp)
        {

            Console.WriteLine(@"CODING TRACKER
____________________________
MAIN MENU

Choose one of the following options:
0 - Exit the application
1 - View all records
2 - Insert record
3 - Delete record
4 - Update record");

            switch (Console.ReadLine())
            {
                case "0":
                    closeApp = true;
                    Environment.Exit(0);
                    break;
                case "1":
                    ViewAllRecords();
                    break;
                case "2":
                    InsertRecord();
                    break;
                case "3":
                    DeleteRecord();
                    break;
                case "4":
                    UpdateRecord();
                    break;
                default:
                    Console.WriteLine("Insert a valid commant");
                    MainMenu();
                    break;
            }
        }
    }

    private static void InsertRecord()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            Console.WriteLine("Gimme the dates");
            string startDateTime = Helpers.GetDateTimeInput("Provide the session start time and date");
            string endDateTime = Helpers.GetDateTimeInput("Provide the session end time and date");

            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                $"INSERT INTO coding_sessions (StartDateTime, EndDateTime) VALUES ('{startDateTime}', '{endDateTime}') ";
            tableCmd.ExecuteNonQuery();
            connection.Close();

        }
    }
    private static void UpdateRecord()
    {
        throw new NotImplementedException();
    }
    private static void DeleteRecord()
    {
        throw new NotImplementedException();
    }
    private static void ViewAllRecords()
    {
        throw new NotImplementedException();
    }
}
