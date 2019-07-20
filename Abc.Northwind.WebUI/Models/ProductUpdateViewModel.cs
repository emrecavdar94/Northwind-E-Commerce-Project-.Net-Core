using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.WebUI.Models
{
    public class ProductUpdateViewModel
    {
        public ProductUpdateViewModel()
        {
            Categories = new List<Category>();
        }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
