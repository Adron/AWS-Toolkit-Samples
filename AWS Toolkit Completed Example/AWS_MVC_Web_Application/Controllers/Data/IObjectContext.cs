using System;
using System.Data.Objects;

namespace AWS_MVC_Web_Application.Data
{
    public interface IObjectContext : IDisposable
    {
        ObjectContextOptions ContextOptions { get; }

        TEntity CreateObject<TEntity>() where TEntity : class;
        IObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}