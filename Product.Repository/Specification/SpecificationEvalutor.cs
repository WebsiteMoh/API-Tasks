using Microsoft.EntityFrameworkCore;
using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Specification
{
    public class SpecificationEvalutor
    {
        public static IQueryable<Products> GetQuery(IQueryable<Products> inputQuery,Ispecification<Products> specs)
        {
            var query = inputQuery;
            if(specs.Cretira is not null)
            {
                query = query.Where(specs.Cretira);
            }
            if(specs.OrderBy is not null)
            {
                query = query.OrderBy(specs.OrderBy);
            }
            if(specs.OrderByDesc is not null)
            {
                query = query.OrderBy(specs.OrderByDesc);
            }
            if (specs.Ispagenated)
            {
                query = query.Skip(specs.Skip).Take(specs.Take);
            }
            query = specs.Includes.Aggregate(query, (current, includeExperssion) => current.Include(includeExperssion));
            return query;
        }
    }
}
