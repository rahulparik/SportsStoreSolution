using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LoggingLibrary;
using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;
using SportsStoreMVCWebApp.Models;

namespace SportsStoreMVCWebApp.Controllers
{
    public class CartController : Controller
    {
        IProductRepository _productRepository;
        ILogger _logger;

        public CartController(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["cart"] = cart;
            }
            return cart;
        }

        public ActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl});
        }

        public ViewResult Summary()
        {
            return View(GetCart());
        }

        public RedirectToRouteResult AddToCart(int? productID, string returnUrl)
        {
            Product prod = _productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
            if (prod != null)
            {
                GetCart().AddItem(prod, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult RemoveFromCart(int productID, string returnUrl)
        {
            Product prod = _productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
            if (prod != null)
            {
                GetCart().RemoveLine(prod);
            }
            return RedirectToAction("Index");
        }

        public ViewResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CheckOut(string name)
        {
            GetCart().Clear();
            return View("Thankyou");
        }

    }
}