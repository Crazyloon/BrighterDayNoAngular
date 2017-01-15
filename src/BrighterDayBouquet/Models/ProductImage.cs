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
    /// Provides a way for products to link to more than one image.
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/3/17
    /// Purpose: This class will model an image that is related to 
    ///             a product. Each product can contain multiple images
    /// </remarks>
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [Required]
        [StringLength(64)]
        public string Alt { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }

        // Navigation
        public virtual Product Product { get; set; }
    }
}
