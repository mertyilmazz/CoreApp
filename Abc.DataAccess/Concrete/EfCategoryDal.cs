using Abc.Core.DataAccess;
using Abc.DataAccess.Abstract;
using Abc.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        public string GetCategoryName(int Id)
        {
            var categoryName = Get(f => f.CategoryId == Id).CategoryName;
            return categoryName;
        }
    }
}
