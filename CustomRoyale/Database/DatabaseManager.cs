using MySql.Data.MySqlClient;

namespace CustomRoyale.Database
{
    public class DatabaseManager
    {
        private static readonly string _server = Resources.Configuration.MySqlServer;
        private static readonly string _database = Resources.Configuration.MySqlDatabase;
        private static readonly string _user = Resources.Configuration.MySqlUserId;
        private static readonly string _password = Resources.Configuration.MySqlPassword;
        private static readonly string _connectionString = $"Server={_server};User ID={_user};Password={_password};SslMode=None;";

        public static async Task InitializeAsync()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS `{_database}`;", connection))
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                Logger.Log("Initialized database", ErrorLevel.Info);

                using (var connection = new MySqlConnection($"{_connectionString}Database={_database};"))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand(@"
                        CREATE TABLE IF NOT EXISTS `player` (
                            `id` BIGINT PRIMARY KEY AUTO_INCREMENT,
                            `username` VARCHAR(50) UNIQUE NOT NULL,
                            `passwordHash` VARCHAR(255) NOT NULL,
                            `trophies` INT DEFAULT 0,
                            `language` VARCHAR(10),
                            `facebookId` VARCHAR(100) UNIQUE,
                            `home` TEXT,
                            `sessions` TEXT
                        );", connection))
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                Logger.Log("Initialized Players table in database", ErrorLevel.Info);
            }
            catch (Exception ex)
            {
                Logger.Log($"Error with MySQL : {ex.Message}", ErrorLevel.Error);
                Logger.Log("Shuting down server, can't connect to database", ErrorLevel.Info);
                Environment.Exit(0);
            }
        }

        public static async Task<int> ExecuteNonQueryAsync(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (var connection = new MySqlConnection($"{_connectionString}Database={_database};"))
                {
                    await connection.OpenAsync();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddRange(parameters);
                        return await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Error with MySQL Query : {ex.Message}", ErrorLevel.Error);
                return -1;
            }
        }

        public static async Task<object?> ExecuteScalarAsync(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (var connection = new MySqlConnection($"{_connectionString}Database={_database};"))
                {
                    await connection.OpenAsync();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddRange(parameters);
                        return await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with MySQL Query : {ex.Message}");
                return null;
            }
        }
    }
}
