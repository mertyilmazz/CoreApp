using Abc.Business.Abstract;
using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abc.Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            var productCount = cart.CartLines.Where(f => f.Product.ProductId == productId).FirstOrDefault().Quantity;
            if (productCount > 1)
            {
                var product = cart.CartLines.FirstOrDefault(f => f.Product.ProductId == productId);
                product.Quantity = product.Quantity - 1;
                return;
            }
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(f => f.Product.ProductId == productId));
        }
    }
}
