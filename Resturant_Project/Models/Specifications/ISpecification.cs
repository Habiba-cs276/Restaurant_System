using System.Linq.Expressions;

namespace Resturant_Project.Models.Specifications
{
    public interface ISpecification<TEntity> where TEntity : class
    { 
        Expression<Func<TEntity, bool>>? Cretaria {  get; }  
        List<Expression<Func<TEntity,object>>> Includes {  get; }
        List<string> IncludeStrings { get; }
        List<OrderExpresionInfo<TEntity>> OrderBy { get; }

        //Expression<Func<TEntity, object>> OrderBy { get; }
        //Expression<Func<TEntity, object>> OrderByDescending { get; }

        //int Take {  get; }  
        //int Skip { get; }  
        //bool IsPagingEnabled {  get; }  



    }
}
