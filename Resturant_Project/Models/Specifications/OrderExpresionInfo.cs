using System.Linq.Expressions;

namespace Resturant_Project.Models.Specifications
{
    public class OrderExpresionInfo<TEntity>
    {
        public Expression<Func<TEntity,object>>? OrderByEx {  get; set; }   
       public bool IsDesc {  get; set; }    
    }
}
