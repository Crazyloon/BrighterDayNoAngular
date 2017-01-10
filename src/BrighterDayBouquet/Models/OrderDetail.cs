using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Models
{
    /// <summary>
    /// Provides a way to store specific details about each order.
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/3/17
    /// Purpose: This class will model the order details of an order
    ///             It will be used to keep historical records of orders and
    ///             their completion status. It will also contain customers notes
    ///             and special request information.
    /// </remarks>
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } // Duplicate data with ShoppingCart.CheckoutDate (possibly remove ShoppingCart.CheckoutDate)

        [Required]
        public bool CompletedOrder { get; set; }

        [Required]
        public DateTime CompletionDate { get; set; }

        [StringLength(500)]
        public string SpecialRequest { get; set; }

        // Navigation Properties
        public Order Order { get; set; }
    }
}
