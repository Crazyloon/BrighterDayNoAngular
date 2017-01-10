using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Models
{
    /// <summary>
    /// Provides a way for users to select how they want their cart items to be packaged
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/3/17
    /// Purpose: This model will be used to determine the vessle the customer would like
    ///             their flowers to be arranged in.
    /// </remarks>
    public class PackageStyle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Style { get; set; } // Can be Vase, Bouquet, None
    }
}
