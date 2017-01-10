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
    /// Provides users with a way to store <see cref="CartItem"/>(s) for future orders.
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 01/03/2017
    /// Purpose: This class will model a shopping cart class, that will be created
    ///             when they add their first Product to a shopping cart.
    ///             A new cart will be created after they have checked out the old cart, and
    ///             added their first Product to the new cart.
    /// </remarks>
    public class ShoppingCart
    {
        // Table Properties
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }


        public DateTime? CheckoutDate { get; set; } // Data duplication between OrderDetails -> OrderDate (consider revisiting this property later)

        // Navigation Properties
        public virtual ApplicationUser User { get; set; }
    }
}
