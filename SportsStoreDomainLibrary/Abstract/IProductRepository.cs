using System.Linq;
using System.Threading.Tasks;
using SportsStoreDomainLibrary.Entities;

namespace SportsStoreDomainLibrary.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Task SaveProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
