using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Business.Abstract;
using Abc.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var model = new ProductListViewModel();
            var products = _productService.GetByCategory(category);
            model.Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            model.PageCount = (int)Math.Ceiling(products.Count / (double)pageSize);
            model.PageSize = pageSize;
            model.CurrentCategoryId = category;
            model.CurrentPage = page;

            return View(model);
        }

      
    }
}