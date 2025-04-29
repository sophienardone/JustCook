using JustCook.Controllers.JustCook.Controllers;
using JustCook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JustCook.Controllers
{
    public class CheckoutController : Controller
    {
        private const string CartKey = "Cart";

        // GET: /Checkout
        public IActionResult Index()
        {
        
            var cart = HttpContext.Session.GetObjectFromJson<Cart>(CartKey) ?? new Cart();                   
            if (!cart.Items.Any())
            {
                TempData["Message"] = "Your cart is empty. Add items before checking out.";
                return RedirectToAction("Index", "Cart");
            }


            return View(cart);
        }

        // POST: /Checkout/Confirm
        [HttpPost]
        public IActionResult Confirm(string name, string address)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>(CartKey) ?? new Cart();                  

            HttpContext.Session.Remove(CartKey);

            ViewBag.Name = name;
            ViewBag.Address = address;
            ViewBag.Total = cart.Total;
            return View("Success");
        }
    }
}
