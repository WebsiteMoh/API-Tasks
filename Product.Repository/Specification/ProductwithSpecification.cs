using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Specification
{
    public class ProductwithSpecification : BaseSpecification<Products>
    {
        public ProductwithSpecification(ProductSpecification specs) :
            base(products => (!specs.BrandID.HasValue || products.BrandId == specs.BrandID.Value) && 
            (!specs.TypeId.HasValue || products.TypeId == specs.TypeId.Value) && (String.IsNullOrEmpty(specs.Search) || products.Name.Trim().ToLower().Contains(specs.Search)))
        {
            //AddInclude(x => x.BrandId);
            //AddInclude(x => x.TypeId);
            OrderByExper(x => x.Name);
            ApplyPagination(specs.PageSize * (specs.PageSize-1),specs.PageSize);

            if (!String.IsNullOrEmpty(specs.Sort))
            {
                switch(specs.Sort)
                {
                    case "priceAsc":
                        OrderByExper(x => x.Price);
                        break;
                    case "PriceDesc":
                        DescOrderByExper(x => x.Price);
                        break;
                    default:
                        OrderByExper(x => x.Name);
                        break;

                }
            }


        }

    }
}
