using Abc.Business.Abstract;
using Abc.DataAccess.Abstract;
using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
