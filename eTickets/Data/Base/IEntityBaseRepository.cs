using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    //In the ASP.NET MVC application you have completed the Actor's section by adding the Create, Read, Update and Delete (CRUD) functionalities.
    //Now, you will need to create the same methods for the Cinemas, Producers, and even Movies. But, instead of repeating the same code over
    //and over again, we are to create a generic base repository.Base or generic repositories are helpful for the main functionality of the app.
    //You code less and you achieve the same goal. On this part, you will add all the necessary EntityBaseRepository files. 
    public interface IEntityBaseRepository<T> where T:class, IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id); //Updating ActorsService and ActorsController with "Async"
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity); //UpdateAsync method in ActorsService
        Task DeleteAsync(int id); //DeleteAsync method in ActorsService
    }
}
