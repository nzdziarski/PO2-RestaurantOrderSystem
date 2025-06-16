using System.Collections.Generic;
using Npgsql;
using PO2_RestaurantOrderSystem.Model;

namespace PO2_RestaurantOrderSystem.Services
{
    public static class MenuService
    {
        public static List<MenuItem> GetAllMenuItems()
        {
            var result = new List<MenuItem>();
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, name, price, category, description FROM menu_items ORDER BY name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new MenuItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Description = reader.IsDBNull(4) ? "" : reader.GetString(4)
                        });
                    }
                }
            }
            return result;
        }

        public static bool MenuItemNameExists(string name, int? excludeId = null)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM menu_items WHERE LOWER(name) = LOWER(@name)";
                if (excludeId.HasValue)
                    sql += " AND id <> @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    if (excludeId.HasValue)
                        cmd.Parameters.AddWithValue("@id", excludeId.Value);
                    var count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void AddMenuItem(MenuItem item)
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO menu_items(name, price, category, description) VALUES (@name, @price, @category, @description)",
                new NpgsqlParameter("@name", item.Name),
                new NpgsqlParameter("@price", item.Price),
                new NpgsqlParameter("@category", item.Category ?? ""),
                new NpgsqlParameter("@description", item.Description ?? "")
            );
        }

        public static void UpdateMenuItem(MenuItem item)
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE menu_items SET name=@name, price=@price, category=@category, description=@description WHERE id=@id",
                new NpgsqlParameter("@name", item.Name),
                new NpgsqlParameter("@price", item.Price),
                new NpgsqlParameter("@category", item.Category ?? ""),
                new NpgsqlParameter("@description", item.Description ?? ""),
                new NpgsqlParameter("@id", item.Id)
            );
        }

        public static void DeleteMenuItem(int id)
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM order_items WHERE menu_item_id=@id",
                new NpgsqlParameter("@id", id)
            );
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM menu_items WHERE id=@id",
                new NpgsqlParameter("@id", id)
            );
        }
    }
}