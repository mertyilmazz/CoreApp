﻿using Abc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {

        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
