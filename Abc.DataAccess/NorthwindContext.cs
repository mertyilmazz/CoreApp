using Abc.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.DataAccess
{
    public class NorthwindContext :DbContext
    {
        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=172.23.213.201;Database=Northwind;User Id=sa;password=Abh12345; Trusted_Connection=false");
            optionsBuilder.UseSqlServer("Server=.;Database=Northwind;Integrated Security=true;");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
