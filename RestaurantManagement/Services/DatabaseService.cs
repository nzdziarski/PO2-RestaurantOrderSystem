using Npgsql;

namespace PO2_RestaurantOrderSystem.Services
{
    public static class DatabaseService
    {
        private static string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=admin;Database=RestaurantDB";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public static void ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, params NpgsqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}