using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int categoryId)
        {
            _categoryDal.Delete(new Category { CategoryId = categoryId });
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public List<Category> GetByCategory(int categoryId)
        {
            return _categoryDal.GetList(x => x.CategoryId == categoryId);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
