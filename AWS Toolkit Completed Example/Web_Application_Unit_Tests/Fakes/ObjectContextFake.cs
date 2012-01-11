using System.Data.Objects;
using AWS_MVC_Web_Application.Data;

namespace Web_Application_Unit_Tests.Fakes
{
    public class ObjectContextFake : IObjectContext
    {
        public void Dispose(){}

        public ObjectContextOptions ContextOptions
        {
            get { return null; }
        }

        public TEntity CreateObject<TEntity>() where TEntity : class
        {
            return null;
        }

        public IObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class
        {
            return null;
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}