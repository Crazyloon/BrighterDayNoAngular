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
    /// Provides database access for Orders.
    /// </summary>
    public class OrderRepository : EFRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public override Order GetById(int id)
        {
            return currentContext.Orders.SingleOrDefault(ord => ord.Id == id);
        }
    }
}
