using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    public class ReviewRepository : EFRepository<Review>
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Review GetById(int id)
        {
            throw new InvalidOperationException("Cannot return Review by single id value.");
        }

        // For sake of consistency, take userID as an integer like all the other ID's
        // but convert it to a string for the sake of the ApplicationUser class requirements
        public Review GetByIds(int userID, int productID)
        {
            string strUserId = userID.ToString();
            return currentContext.Reviews.SingleOrDefault(r => r.UserID == strUserId && r.ProductID == productID);
        }
    }
}
