using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
