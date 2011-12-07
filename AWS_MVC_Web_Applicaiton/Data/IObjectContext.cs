using System;
using System.Data.Objects;

namespace AWS_MVC_Web_Applicaiton.Data
{
    public interface IObjectContext : IDisposable
    {
        ObjectContextOptions ContextOptions { get; }

        TEntity CreateObject<TEntity>() where TEntity : class;
        IObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}