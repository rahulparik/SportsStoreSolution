using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStoreDomainLibrary.Abstract;
using LoggingLibrary;
using System.Diagnostics;

namespace SportsStoreMVCWebApp.Controllers
{
    public class NavController : Controller
    {
        IProductRepository _productRepository;
        ILogger _logger;

        public NavController(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public PartialViewResult Menu(string category = null)
        {
            Stopwatch timeSpan = Stopwatch.StartNew();
            ViewBag.SelectedCategory = category;
            var result = _productRepository.Products.Select(p => p.Category).Distinct().OrderBy(p=>p);
            timeSpan.Stop();
            _logger.LogInformation("NavController", "Menu", timeSpan.Elapsed, "Got the Distinct of Categories");
            return PartialView(result);
        }

       
    }
}