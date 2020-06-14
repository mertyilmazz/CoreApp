using Abc.Core.DataAccess;
using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}
