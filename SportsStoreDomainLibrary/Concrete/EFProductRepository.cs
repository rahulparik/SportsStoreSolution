using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;

namespace SportsStoreDomainLibrary.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        SportsStoreDbContext _context;
        public EFProductRepository()
        {
            _context = new SportsStoreDbContext();
            _context.Database.Log = (log) => { System.Diagnostics.Trace.WriteLine(log); };
        }

        #region IProductRepository Members
        public IQueryable<Product> Products
        {
            get
            {
                return _context.Products;
            }
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                _context.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        } 
        #endregion
    }
}
