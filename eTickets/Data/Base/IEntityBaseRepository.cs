using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class, IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id); //Updating ActorsService and ActorsController with "Async"
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity); //UpdateAsync method in ActorsService
        Task DeleteAsync(int id); //DeleteAsync method in ActorsService
    }
}
