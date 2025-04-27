using JustCook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace JustCook.Controllers
{
    namespace JustCook.Controllers
    {
        public static class SessionExtensions
        {
            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonSerializer.Serialize(value));
            }

            public static T GetObjectFromJson<T>(this ISession session, string key)
            {
                var value = session.GetString(key);
                return value == null ? default : JsonSerializer.Deserialize<T>(value);
            }
        }

        public class CartController : Controller
        {
            private const string CartSessionKey = "Cart";

            private Cart GetCart()
            {
                return HttpContext.Session.GetObjectFromJson<Cart>(CartSessionKey) ?? new Cart();
            }

            private void SaveCart(Cart cart)
            {
                HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            }

            public IActionResult Index()
            {
                var cart = GetCart();
                return View(cart);
            }

            [HttpPost]
            public IActionResult AddToCart(int productId, int quantity = 1)
            {
                // For now, assume product details (e.g. price) are hardcoded or retrieved from the DB.
                // For example, assume you have a cookbook product:
                var cookbook = new Product
                {
                    ProductId = productId,
                    Name = "The Ultimate Cookbook",
                    Description = "A collection of our best recipes.",
                    Price = 29.99M,
                };

                var cart = GetCart();
                var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    cart.Items.Add(new CartItem
                    {
                        ProductId = productId,
                        Product = cookbook,
                        Quantity = quantity,
                        UnitPrice = cookbook.Price
                    });
                }
                SaveCart(cart);

                return RedirectToAction("Index");
            }
        }
    }
}
