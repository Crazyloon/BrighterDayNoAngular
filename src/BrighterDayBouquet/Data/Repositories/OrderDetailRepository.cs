using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    public class OrderDetailRepository : EFRepository<OrderDetail>
    {
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override OrderDetail GetById(int id)
        {
            return currentContext.OrderDetails.FirstOrDefault(ordD => ordD.Id == id);
        }
    }
}
