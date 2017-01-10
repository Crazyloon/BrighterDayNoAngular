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
    /// Provides the models for users to write their thoughts about products.
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/3/17
    /// Purpose: This class will model a product review by a user
    ///             It has a composit key (UserID + ProductID)
    /// </remarks>
    public class Review
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public string UserID { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(64)]
        public string Caption { get; set; }

        [Required]
        [StringLength(500)]
        public string Body { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        //Navigation Properties
        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }



    }
}
