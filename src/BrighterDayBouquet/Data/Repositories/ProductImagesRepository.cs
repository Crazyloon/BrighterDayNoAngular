using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    public class ProductImagesRepository : EFRepository<ProductImage>
    {
        public ProductImagesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override ProductImage GetById(int id)
        {
            return currentContext.ProductImages.SingleOrDefault(pImgs => pImgs.Id == id);
        }
    }
}
