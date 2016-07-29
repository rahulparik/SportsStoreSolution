using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStoreDomainLibrary.Abstract;
using LoggingLibrary;
using System.Diagnostics;
using SportsStoreMVCWebApp.Models;

namespace SportsStoreMVCWebApp.Controllers
{
    [RequireHttps]
    public class ProductController : Controller
    {
        IProductRepository _productRepository;
        ILogger _logger;
        int _pageSize;
        public ProductController(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
            _pageSize = 4;
        }

        public ViewResult List(string category, int page = 1)
        {

            Stopwatch timeSpan = Stopwatch.StartNew();
            var productsList = _productRepository.Products.Where(p => category == null ? true : p.Category == category);

            var result = new ProductsListViewModel
            {
                Products = productsList.OrderBy(p => p.ProductID).Skip((page - 1) * _pageSize).Take(_pageSize),
                PagingInfo = new PagingInfo
                {
                    TotalItems = productsList.Count(),
                    CurrentPage = page,
                    ItemsPerPage = _pageSize
                },
                CurrentCategory = category
            };
            timeSpan.Stop();
            _logger.LogInformation("ProductController", "ListAction", timeSpan.Elapsed, "Getting All the Products");


            #region Without Category
            //Stopwatch timeSpan = Stopwatch.StartNew();
            //var productsList = _productRepository.Products;
            //var result = new ProductsListViewModel
            //{
            //    Products = productsList.OrderBy(p => p.ProductID).Skip((page - 1) * _pageSize).Take(_pageSize),
            //    PagingInfo = new PagingInfo
            //    {
            //        TotalItems = productsList.Count(),
            //        CurrentPage = page,
            //        ItemsPerPage = _pageSize
            //    }
            //};
            //timeSpan.Stop();
            //_logger.LogInformation("ProductController", "ListAction", timeSpan.Elapsed, "Getting All the Products"); 
            #endregion


            #region Raw Paging
            //Stopwatch timeSpan = Stopwatch.StartNew();
            //var result = _productRepository.Products.OrderBy(p=>p.ProductID).Skip((page - 1) * _pageSize).Take(_pageSize);
            //timeSpan.Stop();
            //_logger.LogInformation("ProductController", "ListAction", timeSpan.Elapsed, "Getting All the Products"); 
            #endregion

            #region Without paging
            //Stopwatch timeSpan = Stopwatch.StartNew();
            //var result = _productRepository.Products;
            //timeSpan.Stop();
            //_logger.LogInformation("ProductController", "ListAction", timeSpan.Elapsed, "Getting All the Products"); 
            #endregion

            return View(result);

        }
    }
}