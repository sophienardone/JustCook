using JustCook.Controllers.JustCook.Controllers;
using JustCook.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCook.Controllers
{
    public class ProductsController : Controller
    {
        // Normally you’d inject a DbContext or service here we show a hard-coded list for demo.
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, Name = "The Ultimate Cookbook", Description = "Our best recipes in one volume", Price = 29.99M }

        };

        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (item != null) item.Quantity++;
                else
                {
                    cart.Items.Add(new CartItem
                    {
                        ProductId = productId,
                        Product = product,
                        Quantity = 1,
                        UnitPrice = product.Price
                    });
                }
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}
