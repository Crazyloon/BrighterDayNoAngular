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

        // allow adding new cart items if one does not already exist
        // else update the quantity of the existing cart item.
        public override void Add(CartItem entity)
        {
            CartItem existingCartItem = this.GetByIds(entity.CartID, entity.ProductID, entity.PackageStyleID);
            if (existingCartItem == null)
            {
                base.Add(entity);
            }
            else
            {
                existingCartItem.Quantity += 1;
                this.Update(existingCartItem);
            }            
        }

        public override CartItem GetById(int id)
        {
            throw new InvalidOperationException("Unable to retrieve cart item by just an id. Must include cartID, productID, and packageStyleID");
        }

        public CartItem GetByIds(int cartId, int productId, int packageStyleId)
        {
            return currentContext.CartItems.SingleOrDefault(ci => ci.CartID == cartId && ci.ProductID == productId && ci.PackageStyleID == packageStyleId);
        }
    }
}
