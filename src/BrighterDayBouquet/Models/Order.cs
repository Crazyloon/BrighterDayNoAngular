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
    /// Provides a snap shot of each order 
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/3/17
    /// Purpose: This class will model the order of a cart
    /// </remarks>
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ShoppingCart")]
        public int CartID { get; set; }

        //Navigation Properties
        public ShoppingCart ShoppingCart { get; set; }
    }
}
