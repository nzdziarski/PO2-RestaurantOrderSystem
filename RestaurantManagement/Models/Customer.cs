using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required, MaxLength(15)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
    }
}