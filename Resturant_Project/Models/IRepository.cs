namespace Resturant_Project.Models
{
    public interface IRepository<T> where T : class 
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync( int id, QueryOptions<T> options); 
        Task DeleteAsync( int id ); 
        Task AddAsync( T entity );  
        Task UpdateAsync( T entity );   
    }
}
