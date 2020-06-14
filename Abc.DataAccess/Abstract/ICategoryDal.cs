using System;
using System.Collections.Generic;
using System.Text;
using Abc.Core.DataAccess;
using Abc.Entities.Concrete;

namespace Abc.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
       string GetCategoryName(int Id);
    }
}
