using ECommerce.Models;

namespace ECommerce.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new() // kosul class olacak ve obje alabilecek t herhangı bır harf olabilir 
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);


        Task DeleteAsync(int id);
    }
}
