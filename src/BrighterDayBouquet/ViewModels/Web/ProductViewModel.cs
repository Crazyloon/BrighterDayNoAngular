using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.ViewModels.Web
{
    public class ProductViewModel
    {
        const int descriptionLimit = 120;

        [Required]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(8)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(128)]
        public string ProductName { get; set; }


        private string _productDescription;
        [Required]
        [StringLength(256)]
        public string ProductDescription
        {
            get
            {
                if (this._productDescription.Length > descriptionLimit)
                {
                    return this._productDescription.Substring(0, descriptionLimit) + "...";
                }
                return this._productDescription;
            }
            set { this._productDescription = value; }
        }

        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string MainImage { get; set; }

        [Required]
        [StringLength(64)]
        public string MainImageAltText { get; set; }

        [Range(1, 5)]
        public byte Rating { get; set; } // 1-5 stars (nullable? when null say "be the first to rate"?)
    }
}
