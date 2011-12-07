using System;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace AWS_MVC_Web_Applicaiton.Data
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        private IObjectContext container;
        private IObjectSet<T> objectSet;

        public Repository(IRepositorySession session)
        {
            Session = session;
            container = Session.Container;
        }

        protected IRepositorySession Session { get; private set; }

        private IObjectSet<T> ObjectSet
        {
            get { return objectSet ?? (objectSet = container.CreateObjectSet<T>()); }
        }

        public IQueryable<T> All()
        {
            return ObjectSet;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return ObjectSet.Where(predicate);
        }

        public virtual T Create()
        {
            return container.CreateObject<T>();
        }

        public virtual void Add(T entity)
        {
            ObjectSet.AddObject(entity);
        }

        public virtual void Delete(T entity)
        {
            ObjectSet.DeleteObject(entity);
        }

        public void Attach(T entity)
        {
            ObjectSet.Attach(entity);
        }

        public void Detach(T entity)
        {
            ObjectSet.Detach(entity);
        }
    }
}