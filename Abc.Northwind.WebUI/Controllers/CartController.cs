using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.WebUI.Models;
using Abc.Northwind.WebUI.Services;
using Abc.Northwind.WebUI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionService cartSessionService , IProductService productService)
        {
            _cartService = cartService;
            _cartSessionService = cartSessionService;
            _productService = productService;
        }
        public ActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart,productToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", $"Your Product,{productToBeAdded.ProductName}, was successfully add to cart!");
           return RedirectToAction("Index", "Product");
        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel cartSummaryViewModel =new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(cartSummaryViewModel);
        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart,productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", "Your Product was successfully removed to cart!");
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }
        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            TempData.Add("message", $"Thank you {shippingDetails.FirstName}, yo order is in process");
            return View();
        }
    }
}