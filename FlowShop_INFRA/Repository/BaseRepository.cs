using FlowShop_INFRA.Context;
using FlowShop_INFRA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowShop_INFRA.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly FlowShopContext _baseContext;

        public BaseRepository(FlowShopContext baseContext)
        {
            _baseContext = baseContext;
        }

        public virtual T Add(T entity)
        {
            var newEntity = _baseContext.Set<T>().Add(entity);
            _baseContext.SendChanges();
            return newEntity.Entity;
        }

        public virtual void Delete(int id)
        {
            var data = Get(id);
            if (data != null)
            {
                _baseContext.Set<T>().Remove(data);
                _baseContext.SendChanges();
            }
        }

        public virtual T Get(int id)
        {
            return _baseContext.Set<T>().Find(id);
        }

        public virtual T Update(T entity)
        {
            _baseContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _baseContext.SendChanges();
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _baseContext.Set<T>().ToList();
        }
    }
}
