using Microsoft.EntityFrameworkCore;

namespace Resturant_Project.Models.Specifications
{
    public static class EvaluatorSpecification
    {
        public static  IQueryable<TEntity>GenerateQuery<TEntity>
            (IQueryable<TEntity> Basequery, ISpecification<TEntity> specification)
             where TEntity :class
        {
            var query = Basequery;
            //where 
            #region where
            if (specification.Cretaria!= null)
                query=query.Where(specification.Cretaria);
            #endregion

            //Join 
            if (specification.Includes!= null && specification.Includes.Any())
            {
               foreach(var include in specification.Includes)
                {
                    query=query.Include(include);   
                }   
            }
            if (specification.IncludeStrings != null && specification.IncludeStrings.Any())
            {
                foreach (var include in specification.IncludeStrings)
                {
                    query.Include(include);
                }
            }
            //Order
            #region order
            if (specification.OrderBy!= null && specification.OrderBy.Any())
            {
                var orderby=specification.OrderBy.FirstOrDefault();
                IOrderedQueryable<TEntity> orderQuery= orderby.IsDesc?
                    query.OrderByDescending(orderby.OrderByEx)
                    : query.OrderBy(orderby.OrderByEx);

                for (int i = 1; i < specification.OrderBy.Count; i++) 
                {
                    orderby = specification.OrderBy[i];
                    orderQuery = orderby.IsDesc ?
                    orderQuery.ThenByDescending(orderby.OrderByEx)
                    : orderQuery.ThenBy(orderby.OrderByEx);

                }
                query=orderQuery;
                
            }
            #endregion

            return query;   

        }
    }
}
