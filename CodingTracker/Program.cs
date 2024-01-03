﻿using Microsoft.Data.Sqlite;
using CodingTracker;
using ConsoleTableExt;
using System.Security.Cryptography;

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
                EndDateTime TEXT,
                Duration TEXT)";

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

            Console.WriteLine(@"

CODING TRACKER
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
            string duration = Helpers.CalculateDuration(endDateTime, startDateTime);

            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                $"INSERT INTO coding_sessions (StartDateTime, EndDateTime, Duration) VALUES ('{startDateTime}', '{endDateTime}', '{duration}') ";
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
        Console.Clear();
        ViewAllRecords();

        using (var connection = new SqliteConnection(connectionString))
        {
            string recordId = Helpers.GetNumperInput("\nPlease type the Id of the record you want to delete, or type 0 to return to main menu");

            if (recordId == "0")
            {
                MainMenu();
            }
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"DELETE from coding_sessions WHERE Id = '{recordId}'";

            int rowCount = tableCmd.ExecuteNonQuery();

            if (rowCount == 0)
            {
                Console.WriteLine($"\nRecord with Id {recordId} doesn't exist.");
                DeleteRecord();
            }

            Console.WriteLine($"\nRecord with Id {recordId} was deleted."); 

            if (rowCount > 0)
            {
                Console.WriteLine("\nType 0 to continue to main menu or any other key to delete another record.");

                if (Console.ReadLine() == "0") MainMenu();
                else DeleteRecord();
            } else if (rowCount < 1)
            {
                Console.WriteLine("Press Enter to continue to main menu");
                Console.ReadKey();
            }

            connection.Close();
            MainMenu();
        }
    }
    private static void ViewAllRecords()
    {
        Console.Clear();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                $"SELECT * FROM coding_sessions ";

            List<CodingSession> tableData = new();
            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableData.Add(new CodingSession
                    {
                        Id = reader.GetInt32(0),
                        StartDateTime = reader.GetString(1),
                        EndDateTime = reader.GetString(2),
                        Duration = reader.GetString(3)
                    });
                }
            }
            else Console.WriteLine("No rows found");

            connection.Close();

            ConsoleTableBuilder
                .From(tableData)
                .ExportAndWrite();
        }
    }
}