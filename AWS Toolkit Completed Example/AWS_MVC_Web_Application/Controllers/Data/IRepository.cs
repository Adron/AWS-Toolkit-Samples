using System;
using System.Linq;
using System.Linq.Expressions;

namespace AWS_MVC_Web_Application.Data
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        TEntity Create();

        void Add(TEntity entity);
        void Delete(TEntity entity);

        void Attach(TEntity entity);
        void Detach(TEntity entity);
    }
}