using BrighterDayBouquet.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Repositories
{
    /// <summary>
    /// Handles all database interaction except GetById.
    /// </summary>
    /// <typeparam name="T">T is the model carrying the database table you wish to query.</typeparam>
    public abstract class EFRepository<T> : IRepository<T> where T : class
    {
        // Private field
        private ApplicationDbContext _context;
        // Public property
        public ApplicationDbContext currentContext
        {
            get { return _context; }
        }

        // Ctor
        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implemented methods
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Abstract method left to implement
        public abstract T GetById(int id);        
    }
}
