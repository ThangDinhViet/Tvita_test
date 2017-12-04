using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.DAL.Common
{
    public interface IRepository<TEntity, in TKey> : IDisposable where TEntity : class
    {
        TEntity GetById(TKey id);
        ICollection<TEntity> GetAll();
        IQueryable<TEntity> QueryAll();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault();
        TEntity FirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        void Save();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(TKey id);
    }
}
