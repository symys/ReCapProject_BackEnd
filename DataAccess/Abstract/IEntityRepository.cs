using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // filtre null, filtre vermeyedebilirsin demek, filtre vermezse tüm datayı getirir, filtre verirse ona göre getirir
        T Get(Expression<Func<T, bool>> filter); //tek bir detaya gitmek için kullanılır
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
