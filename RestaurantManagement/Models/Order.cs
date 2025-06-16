using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PO2_RestaurantOrderSystem.Model;

namespace RestaurantManagement.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Required]
        [Column("table_id")]
        public int TableId { get; set; }

        [NotMapped]
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}