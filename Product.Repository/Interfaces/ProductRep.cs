using Microsoft.EntityFrameworkCore;
using Product.Data.Context;
using Product.Data.Data;
using Product.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Interfaces
{
    public class ProductRep : IProduct
    {
        private readonly ProductDBcontext _context;
        public ProductRep(ProductDBcontext context) {
            _context = context;
        }

        public IEnumerable<ProductBrand> GetallBrands()
        {
            return _context.ProductsBrand.ToList();
        }

        public async Task<List<Products>> GetallProducts()
        => await _context.Products.ToListAsync();

        public async Task<List<Products>> GetallProducts(Ispecification<Products> specs)
       => await SpecificationEvalutor.GetQuery(_context.Set<Products>(), specs).ToListAsync();

        public IEnumerable<ProductType> GetallTypes()
        {
            return _context.ProductsType.ToList();
        }
       public async Task<List<Products>> GetProductByID(int ID)
        {
            var products= await _context.Products.Where(pro=>pro.ID == ID).ToListAsync();
            return products;
        }
        public async Task<List<Delivery>> GetDeliverytByID(int ID)
        {
            var products = await _context.Deliveries.Where(pro => pro.ID == ID).ToListAsync();
            return products;
        }

        public async Task<List<Delivery>> GetDelivery()
        {
          return  await _context.Deliveries.ToListAsync();
        }
    }
}
