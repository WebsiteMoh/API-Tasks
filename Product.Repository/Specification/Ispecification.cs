using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Specification
{
    public interface  Ispecification<T>
    {
        Expression<Func<T, bool>> Cretira { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, Object>> OrderBy { get; }
        Expression<Func<T, Object>> OrderByDesc { get; }
        int Skip { get; }
        int Take { get; }
        bool Ispagenated { get; }







    }
}
