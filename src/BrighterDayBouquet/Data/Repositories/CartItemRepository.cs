using BrighterDayBouquet.Data.Contracts;
using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    /// <summary>
    /// Provides database access for CartItems.
    /// </summary>
    public class CartItemRepository : EFRepository<CartItem>
    {
        public CartItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override CartItem GetById(int id)
        {
            return currentContext.CartItems.SingleOrDefault(cItms => cItms.Id == id);
        }
    }
}
