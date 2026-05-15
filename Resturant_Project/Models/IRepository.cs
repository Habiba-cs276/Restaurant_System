using Resturant_Project.Models.Specifications;

namespace Resturant_Project.Models
{
    public interface IRepository<T> where T : class 
    {
        Task<IEnumerable<T>>GetAllWithSpecAsync(ISpecification<T>specification);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdWithSpecAsync( int id,ISpecification<T> specification); 
        Task DeleteAsync( int id ); 
        Task AddAsync( T entity );  
        Task UpdateAsync( T entity );
        void Save();
    }
}
