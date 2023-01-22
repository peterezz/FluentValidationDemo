using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
         IQueryable<TEntity> GetAll();
         TEntity GetOne(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where = null,params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Get<TKey>(TKey id);
        void Add(TEntity entity);
        void Delete(int Id);
        void Edit(TEntity entity);

    }
}
