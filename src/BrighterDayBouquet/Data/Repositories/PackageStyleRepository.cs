using BrighterDayBouquet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    public class PackageStyleRepository : EFRepository<PackageStyle>
    {
        public PackageStyleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override PackageStyle GetById(int id)
        {
            return currentContext.PackageStyles.SingleOrDefault(ps => ps.Id == id);
        }
    }
}
