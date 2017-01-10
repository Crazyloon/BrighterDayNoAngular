using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Contracts
{
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/6/17
    /// Purpose: This interface will implement all of the specific <see cref="IRepository{T}"/>
    /// </remarks>
    public interface IBrighterDayUow
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<CartItem> CartItems { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderDetail> OrderDetails { get; }
        IRepository<PackageStyle> PackageStyles { get; }
        IRepository<Product> Products { get; }
        IRepository<Review> Reviews { get; }
        IRepository<ShoppingCart> ShoppingCarts { get; }

        void Commit();
    }
}
