using LoggingLibrary;
using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SportsStoreMVCWebApp.Controllers
{
    //[Authorize]
    [SportsStoreAttributes.SportsStoreAdmin]
    public class AdminController : Controller
    {
        IProductRepository _productRepository;
        ILogger _logger;

        public AdminController(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        } 

        //[AllowAnonymous]
        public ActionResult Index()
        {
            Stopwatch timeSpan = Stopwatch.StartNew();
            var productList = _productRepository.Products;
            timeSpan.Stop();
            _logger.LogInformation("AdminController", "Index Action", timeSpan.Elapsed, "Getting all the products"); 
            return View(productList);
        }

        public ActionResult Edit(int productID)
        {
            Stopwatch timeSpan = Stopwatch.StartNew();
            Product prod = _productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
            timeSpan.Stop();
            _logger.LogInformation("AdminController", "Edit Action", timeSpan.Elapsed, string.Format("Got Single Product, ProductID: {0}", productID));
            return View(prod);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                Stopwatch timeSpan = Stopwatch.StartNew();
                await _productRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0}, has been Updated ", product.ProductName);
                timeSpan.Stop();
                _logger.LogInformation("AdminController", "Post Edit Action", timeSpan.Elapsed, string.Format("Updated a Single Product, ProductID: ", product.ProductID));
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit", new Product { ProductID = 0 });
        }


        public async Task<ActionResult> Delete(int productID)
        {
            Stopwatch timeSpan = Stopwatch.StartNew();
            var result = _productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
            await _productRepository.DeleteProduct(result);
            timeSpan.Stop();
            _logger.LogInformation("AdminController", "Delete Action", timeSpan.Elapsed, string.Format("Deleted Single Product, ProductID: {0}", productID));
            return RedirectToAction("Index");
        }

    }
}