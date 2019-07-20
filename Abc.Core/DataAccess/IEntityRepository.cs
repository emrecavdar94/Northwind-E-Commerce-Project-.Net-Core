using Abc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Abc.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new() //IEntity sınıfı gelicek newlenebilir bir sınıf gelcek interface veya abstract gelemez
    {
        T Get(Expression<Func<T, bool>> filter = null);//default paramater is null
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
