using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Abc.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace Abc.MvcWebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var ProductListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(ProductListViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel model)
        {
            _productService.Add(model.Product);
            TempData.Add("message", "Product was succesfully added");
            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Categories = _categoryService.GetAll(),
                Product = _productService.GetById(productId),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel model)
        {
            _productService.Update(model.Product);
            TempData.Add("message", "Product was succesfully updated");
            return RedirectToAction("Update");
        }

        public ActionResult Delete(int productId)
        {
            if (productId > 0)
            {
                TempData.Add("message", "Product was succesfully deleted");
                _productService.Delete(productId);
            }
            else
                TempData.Add("message", "Product was not succesfully delete");
            return RedirectToAction("Index");
        }

    }
}