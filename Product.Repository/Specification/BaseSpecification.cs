using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Specification
{
    public class BaseSpecification<T> : Ispecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> cretira) {
            Cretira=cretira;
        }
        public Expression<Func<T, bool>> Cretira { get; }

        public List<Expression<Func<T, object>>> Includes { get;  } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool Ispagenated { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> include) { Includes.Add(include); }
        protected void OrderByExper(Expression<Func<T, object>> Order) { OrderBy = Order; }
        protected void DescOrderByExper(Expression<Func<T, object>> Order) { OrderBy = Order; }
        protected void ApplyPagination(int skip,int take) { Take = take; Skip = skip; Ispagenated = true; }


    }
}
