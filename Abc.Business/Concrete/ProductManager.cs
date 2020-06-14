using Abc.Business.Abstract;
using Abc.DataAccess.Abstract;
using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(f => f.CategoryId == categoryId || categoryId == 0);
        }

        public Product GetById(int productId)
        {
            var product = _productDal.Get(p => p.ProductId == productId);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
