using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Data.Contracts
{
    /// <summary>
    /// Provides data contracts to interact with the database.
    /// </summary>
    /// <remarks>
    /// Author: Russell Dow.
    /// Created: 1/6/17
    /// Purpose: This is a generic contract to ensure common data access across
    ///             all specific repository implementations.
    /// </remarks>
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);        
    }
}
