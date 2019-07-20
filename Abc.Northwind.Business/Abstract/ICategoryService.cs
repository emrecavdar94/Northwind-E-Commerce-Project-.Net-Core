using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.Business.Concrete
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetByCategory(int categoryId);
        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
    }
}
