﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Models
{
     /// <summary>
     /// Acts as the model for storing information about specific products.
     /// </summary>
     /// <remarks>
     /// Author: Russell Dow.
     /// Created: 1/3/17
     /// Purpose: This class will model a product that can be
     ///             purchased by customers
     /// </remarks>
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(128)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(256)]
        public string ProductDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string MainImage { get; set; }

        [Range(1,5)]
        public byte Rating { get; set; } // 1-5 stars (nullable? when null say "be the first to rate"?)


    }
}
