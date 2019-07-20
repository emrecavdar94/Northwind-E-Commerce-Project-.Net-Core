using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace Abc.Northwind.WebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck==null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart()); // sepet boşşa yeni bir nesne gönderiyoruz
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
