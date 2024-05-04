using MySql.Data.MySqlClient;

namespace KainmunityServer.DataAccess
{
    public class DatabaseConnector
    {
        private static string _connectionString;

        static DatabaseConnector()
        {
            _connectionString = GetConnectionString();
        }

        private static string GetConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DB_SERVER");
            string port = Environment.GetEnvironmentVariable("DB_PORT");
            string database = Environment.GetEnvironmentVariable("DB_DATABASE");
            string username = Environment.GetEnvironmentVariable("DB_USERNAME");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            return $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};";
        }

        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public static async Task PingDatabase()
        {
            Console.WriteLine("Connecting to database...");

            var res = await ExecuteQuery("SELECT 1");

            if (res.Count > 0)
            {
                Console.WriteLine("Successfully connected to database.");
            }
        }

        public static async Task<List<Dictionary<string, object>>> ExecuteQuery(string query, Dictionary<string, object>? parameters = null)
        {
            parameters ??= new Dictionary<string, object>();
            List<Dictionary<string, object>> results = new();

            try
            {
                using MySqlConnection connection = GetConnection();

                using MySqlCommand command = new MySqlCommand(query, connection);
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                await connection.OpenAsync();

                using MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }

                    results.Add(row);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return results;
        }

        public static async Task<int> ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
        {
            parameters ??= new Dictionary<string, object>();
            int rowsAffected = 0;

            try
            {
                using MySqlConnection connection = GetConnection();
                using MySqlCommand command = new MySqlCommand(query, connection);
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                await connection.OpenAsync();
                rowsAffected = await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return rowsAffected;
        }
    }
}
