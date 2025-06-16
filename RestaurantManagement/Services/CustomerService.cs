using Npgsql;
using PO2_RestaurantOrderSystem.Services;
using RestaurantManagement.Models;
using System.Data;

namespace RestaurantManagement.Services
{
    public class CustomerService
    {
        public static int AddCustomer(Customer customer)
        {
            var sql = "INSERT INTO customers (first_name, last_name, phone_number) VALUES (@fn, @ln, @pn) RETURNING id";
            var id = DatabaseService.ExecuteScalar(sql,
                new NpgsqlParameter("@fn", customer.FirstName),
                new NpgsqlParameter("@ln", customer.LastName),
                new NpgsqlParameter("@pn", customer.PhoneNumber));
            return (int)id;
        }
    }
}