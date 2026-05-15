
using Microsoft.EntityFrameworkCore;
using Resturant_Project.Data;
using Resturant_Project.Models.Specifications;

namespace Resturant_Project.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _Context;
        private DbSet<T> _dbSet; 
        public Repository(ApplicationDbContext context)
        {
            _Context = context; 
            _dbSet= context.Set<T>();   
        }
        public async Task AddAsync(T entity)
        {
         await _dbSet.AddAsync(entity); 
        }

        public async Task DeleteAsync(int id)
        {
            T? entity;
            entity = await _dbSet.FindAsync(id);
            if(entity != null) 
           _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await _dbSet.ToListAsync();    
        }

        public async Task<T> GetByIdAsync(int id)
        {
          return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
             _dbSet.Update(entity);
        }
        public void Save()
        {
            _Context.SaveChanges(); 
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> specification)
        {
            var BaseQuery = _dbSet;
            var Query = EvaluatorSpecification.GenerateQuery(BaseQuery, specification); 
             return await Query.ToListAsync();  
        }

        public async Task<T> GetByIdWithSpecAsync(int id, ISpecification<T> specification)
        {
            var BaseQuery = _dbSet;
            var Query = EvaluatorSpecification.GenerateQuery(BaseQuery, specification);
            return await Query.FirstOrDefaultAsync();
        }
    }
}
