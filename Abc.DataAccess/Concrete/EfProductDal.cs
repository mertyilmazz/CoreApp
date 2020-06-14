using Abc.Core.DataAccess;
using Abc.DataAccess.Abstract;
using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.DataAccess.Concrete
{
   public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {

    }
}
