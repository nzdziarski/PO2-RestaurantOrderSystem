using System.Collections.Generic;
using Npgsql;
using PO2_RestaurantOrderSystem.Model;

namespace PO2_RestaurantOrderSystem.Services
{
    public static class TableService
    {
        public static List<Table> GetAllTables()
        {
            var result = new List<Table>();
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, number, is_reserved FROM tables ORDER BY number", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Table
                        {
                            Id = reader.GetInt32(0),
                            Number = reader.GetInt32(1),
                            IsReserved = reader.GetBoolean(2)
                        });
                    }
                }
            }
            return result;
        }

        public static void AddTable(Table table)
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO tables(number, is_reserved) VALUES (@number, @is_reserved)",
                new NpgsqlParameter("@number", table.Number),
                new NpgsqlParameter("@is_reserved", table.IsReserved)
            );
        }

        public static void UpdateTable(Table table)
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE tables SET number=@number, is_reserved=@is_reserved WHERE id=@id",
                new NpgsqlParameter("@number", table.Number),
                new NpgsqlParameter("@is_reserved", table.IsReserved),
                new NpgsqlParameter("@id", table.Id)
            );
        }

        public static void DeleteTable(int id)
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM tables WHERE id=@id",
                new NpgsqlParameter("@id", id)
            );
        }

        public static bool TableNumberExists(int number, int? excludeId = null)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM tables WHERE number = @number";
                if (excludeId.HasValue)
                {
                    sql += " AND id <> @id";
                }
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@number", number);
                    if (excludeId.HasValue)
                        cmd.Parameters.AddWithValue("@id", excludeId.Value);
                    var count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}