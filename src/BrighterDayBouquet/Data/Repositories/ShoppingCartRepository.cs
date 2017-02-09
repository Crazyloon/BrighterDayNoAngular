using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    public class ShoppingCartRepository : EFRepository<ShoppingCart>
    {
        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override ShoppingCart GetById(int id)
        {
            return currentContext.ShoppingCarts.SingleOrDefault(sC => sC.Id == id);
        }

        public virtual ShoppingCart GetByUserID(string userID)
        {
            return currentContext.ShoppingCarts.SingleOrDefault(sC => sC.UserID == userID);
        }
    }
}
