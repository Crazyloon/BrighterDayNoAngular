using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    public class ProductRepository : EFRepository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Product GetById(int id)
        {
            return currentContext.Products.SingleOrDefault(p => p.Id == id);
        }
    }
}
