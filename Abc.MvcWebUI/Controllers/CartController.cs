using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Business.Abstract;
using Abc.Entities.Concrete;
using Abc.MvcWebUI.Models;
using Abc.MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }
        public IActionResult AddToCart(int productId)
        {
            var product = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, product);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product {0}, was successfully added to the cart", product.ProductName));
            return RedirectToAction("Index", "Product");
        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            var model = new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(model);
        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product was successfully deleted to the cart"));
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var model = new ShippingDetailViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Complete(ShippingDetailViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            TempData.Add("message", String.Format("Thank you {0}, you order is in process",model.ShippingDetails.FirstName));
            return View();
        }
    }
}