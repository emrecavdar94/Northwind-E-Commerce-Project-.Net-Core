using Abc.Northwind.Business.Concrete;
using Abc.Northwind.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;

namespace Abc.Northwind.WebUI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index(int page=1,int category=0)
        {
            int pageSize = 10;
            var products = _productService.GetByCategory(category);
            ProductListViewModel model = new ProductListViewModel {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(), // (page-1)*10 kadar ürünü atlayarak al
                PageCount=(int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize=pageSize,
                CurrentCategory=category,
                CurrentPage=page
            };
            return View(model);
        }
        //public void Session()
        //{
        //    HttpContext.Session.SetString("city", "Ankara");
        //    HttpContext.Session.SetInt32("age", 32);
           
        //    HttpContext.Session.GetString("city");
        //}
        //public ActionResult AddToCart()
        //{

        //}
    }
}
