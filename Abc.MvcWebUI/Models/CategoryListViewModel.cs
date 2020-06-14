﻿using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories{ get; set; } 

        public int CurrentCategoryId { get; set; }

    }
}
