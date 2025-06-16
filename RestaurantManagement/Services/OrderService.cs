using System.Collections.Generic;
using System.Linq;
using Npgsql;
using PO2_RestaurantOrderSystem.Model;
using RestaurantManagement.Models;

namespace PO2_RestaurantOrderSystem.Services
{
    public static class OrderService
    {
        public static int CreateOrder(int tableId, List<OrderItem> items)
        {
            int orderId = 0;
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    using (var cmd = new NpgsqlCommand("INSERT INTO orders(table_id, date) VALUES(@table_id, NOW()) RETURNING id", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@table_id", tableId);
                        orderId = (int)cmd.ExecuteScalar();
                    }
                    foreach (var item in items)
                    {
                        using (var cmd = new NpgsqlCommand("INSERT INTO order_items(order_id, menu_item_id, quantity, price) VALUES (@order_id, @menu_item_id, @quantity, @price)", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@order_id", orderId);
                            cmd.Parameters.AddWithValue("@menu_item_id", item.MenuItemId);
                            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@price", item.Price);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                }
            }
            return orderId;
        }

        private static List<Order> orders = new List<Order>();

        public static Order GetOrderByTableId(int tableId)
        {
            return orders.FirstOrDefault(o => o.TableId == tableId);
        }

        public static void AddOrUpdateOrder(Order order)
        {
            var existing = orders.FirstOrDefault(o => o.TableId == order.TableId);
            if (existing != null)
            {
                existing.Items = order.Items;
            }
            else
            {
                orders.Add(order);
            }
        }

        public static (int OrderId, List<OrderItem> Items) GetCurrentOrderWithItemsByTableId(int tableId)
        {
            int orderId = 0;
            var items = new List<OrderItem>();
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                // Pobierz ID ostatniego zamówienia dla stolika
                using (var cmd = new NpgsqlCommand("SELECT id FROM orders WHERE table_id=@table_id ORDER BY date DESC LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@table_id", tableId);
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                        return (0, items);
                    orderId = (int)result;
                }
                // Pobierz pozycje zamówienia
                using (var cmd = new NpgsqlCommand("SELECT oi.menu_item_id, mi.name, oi.price, oi.quantity FROM order_items oi JOIN menu_items mi ON oi.menu_item_id = mi.id WHERE oi.order_id=@order_id", conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new OrderItem
                            {
                                MenuItemId = reader.GetInt32(0),
                                MenuItemName = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Quantity = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return (orderId, items);
        }

        // Nadpisz pozycje zamówienia (usuwa stare i dodaje nowe)
        public static void UpdateOrderItems(int orderId, List<OrderItem> items)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    // Usuń istniejące pozycje
                    using (var cmd = new NpgsqlCommand("DELETE FROM order_items WHERE order_id=@order_id", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@order_id", orderId);
                        cmd.ExecuteNonQuery();
                    }
                    // Dodaj nowe pozycje
                    foreach (var item in items)
                    {
                        using (var cmd = new NpgsqlCommand("INSERT INTO order_items(order_id, menu_item_id, quantity, price) VALUES (@order_id, @menu_item_id, @quantity, @price)", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@order_id", orderId);
                            cmd.Parameters.AddWithValue("@menu_item_id", item.MenuItemId);
                            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@price", item.Price);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                }
            }
        }

        public static void RemoveOrder(int tableId)
        {
            var order = orders.FirstOrDefault(o => o.TableId == tableId);
            if (order != null)
                orders.Remove(order);
        }

        public static List<Order> GetAllOrders()
        {
            return orders;
        }

        // NOWA METODA: usuwa zamówienie z bazy dla danego stolika
        public static void RemoveOrderFromDatabase(int tableId)
        {
            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                // Znajdź ostatnie zamówienie dla stolika
                int? orderId = null;
                using (var cmd = new NpgsqlCommand("SELECT id FROM orders WHERE table_id=@table_id ORDER BY date DESC LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@table_id", tableId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        orderId = (int)result;
                }
                if (orderId.HasValue)
                {
                    // Usuń pozycje zamówienia
                    using (var cmd = new NpgsqlCommand("DELETE FROM order_items WHERE order_id=@order_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@order_id", orderId.Value);
                        cmd.ExecuteNonQuery();
                    }
                    // Usuń zamówienie
                    using (var cmd = new NpgsqlCommand("DELETE FROM orders WHERE id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}