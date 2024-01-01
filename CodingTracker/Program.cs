using Microsoft.Data.Sqlite;

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
    }

}
