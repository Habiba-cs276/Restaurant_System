using System.Linq.Expressions;

namespace Resturant_Project.Models.Specifications
{
    public class BaseSpecifications<TEntity> : ISpecification<TEntity> where TEntity : class    
    {
        public  BaseSpecifications()
        {
            Cretaria = x => true;
        }
        #region Where
        public Expression<Func<TEntity, bool>> Cretaria { get;private set; }  
        public BaseSpecifications(Expression<Func<TEntity, bool>> _cretaria) =>Cretaria = _cretaria;
        #endregion
     
        #region Include

        public List<Expression<Func<TEntity, object>>> Includes { get; private set; } = new List<Expression<Func<TEntity, object>>>();  
        public void AddInclude(Expression<Func<TEntity, object>> _includeExpresion)=>Includes.Add(_includeExpresion);
        public List<string> IncludeStrings { get; } = new List<string>();
        public void AddIncludeString(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        #endregion

        #region Ordering
        public List<OrderExpresionInfo<TEntity>> OrderBy { get; private set; }
        public void AddOrder(Expression<Func<TEntity, object>> _orderexpresion, bool isDesc=false) 
            => OrderBy.Add(new OrderExpresionInfo<TEntity>
            {
                IsDesc= isDesc, 
                OrderByEx= _orderexpresion
            });
        //public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
        //protected void OrderDsc(Expression<Func<TEntity, object>> _orderexpresion) => OrderByDescending = _orderexpresion;
        #endregion

        //public int Take => throw new NotImplementedException();

        //public int Skip => throw new NotImplementedException();

        //public bool IsPagingEnabled => throw new NotImplementedException();
    }
}
