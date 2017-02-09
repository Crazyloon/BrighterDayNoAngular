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
    /// Provides a model which can be used to list products in a users cart.
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/3/17
    /// Purpose: This class will model a cart item, which can be a single product
    ///             with a package style and quantity
    /// </remarks>
    public class CartItem
    {
        [Key, Column(Order = 0)]
        [ForeignKey("ShoppingCart")]
        public int CartID { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("PackageStyle")]
        public int PackageStyleID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool isCheckedOut { get; set; }

        //Navigation Properties
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Product Product { get; set; }
        public virtual PackageStyle PackageStyle { get; set; }
    }
}
