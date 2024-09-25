﻿using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services
{
    public interface IproductServices
    {
        IEnumerable<Products> GetallProducts();
        IEnumerable<ProductBrand> GetallBrands();
        IEnumerable<ProductType> GetallTypes();

    }
}
