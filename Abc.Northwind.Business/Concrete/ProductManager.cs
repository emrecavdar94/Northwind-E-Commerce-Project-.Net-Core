using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Abc.Northwind.Business.Abstract;

namespace Abc.Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(x => x.CategoryID == categoryId || categoryId==0);
        }

        public Product GetById(int productId)
        {
           return _productDal.Get(x => x.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
