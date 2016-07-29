using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;

namespace SportsStoreMVCWebApp.Infrastructure
{
    public class MockProduct : IProductRepository
    {
        public IQueryable<Product> Products
        {
            get
            {

                return new List<Product>
            {
                    new Product { ProductName="Kayak123", Description="A boat for one person", Price=275.00m, Category="Watersports"},
                    new Product { ProductName="Unsteady Chair", Description="Secretly give your opponent a disadvantage", Price=29.95m, Category="Chess"},
                    new Product { ProductName="Lifejacket123", Description="Protective and fashionable", Price=48.95m, Category="Watersports"},
                    new Product { ProductName="Soccer ball123", Description="FIFA-approved size and weight", Price=19.50m, Category="Soccer"},
                    new Product { ProductName="Spalding Ball", Description="NBA official Basketball", Price=160.00m, Category="Basketball"},
                    new Product { ProductName="Corner flags", Description="Give your playing field that professional touch", Price=34.95m, Category="Soccer"},
                    new Product { ProductName="Stadium", Description="Flat-packed 35,000-seat stadium", Price=79500.00m, Category="Soccer"},
                    new Product { ProductName="Thinking cap", Description="Improve your brain efficiency by 75%", Price=16.00m, Category="Chess"},
                    new Product { ProductName="Ring Net", Description="NBA size ring nets", Price=60.00m, Category="Basketball"},
                    new Product { ProductName="Human Chess", Description="A fun game for the whole family", Price=75.00m, Category="Chess"},
                    new Product { ProductName="Bling-bling King", Description="Gold-plated, diamond-studded King", Price=1200.00m, Category="Chess"},
                    new Product { ProductName="Dark Night", Description="Titanium-plated Knight", Price=800.00m, Category="Chess"},
                    new Product { ProductName="Shoe", Description="Studded shoes", Price=950.00m, Category="Soccer"},
                    new Product { ProductName="Basketball Boards", Description="Full size NBA size Boards", Price=2160.00m, Category="Basketball"},
                    new Product { ProductName="Jersey", Description="Air Jersey", Price=1200.00m, Category="Soccer"},
                    new Product { ProductName="Scooter", Description="A water bike for one or two people", Price=4275.00m, Category="Watersports"},
                    new Product { ProductName="Fox 40 whistle", Description="NBA Referres Whistel", Price=160.00m, Category="Basketball"},
                    new Product { ProductName="Surfboard", Description="Surfboard for surfing on water", Price=495.00m, Category="Watersports"}
            }.AsQueryable();


            }
        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}