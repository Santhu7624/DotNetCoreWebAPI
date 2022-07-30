using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Model.Entities;
using EComm.Model.Specification;
using Microsoft.EntityFrameworkCore;

namespace EComm.DataAccess.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> includeQuery,
        ISpecification<TEntity> spec)
        {
            var query = includeQuery;
            // Ordering is Important
            // Filtering operators => 1st
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            // Sorting Operators => 2nd
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            // Paging Operators => 3rd
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes
                        .Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}