using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentCategoryId { get; set; }

        public int CurrentPage { get; set; }
    }
}
