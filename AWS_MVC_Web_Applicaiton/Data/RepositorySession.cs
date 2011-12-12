using System;

namespace AWS_MVC_Web_Application.Data
{
    public class RepositorySession : IRepositorySession
    {
        public static Type DefaultContainerType { get; set; }

        [ThreadStatic]
        private static RepositorySession _current;

        public static RepositorySession Current
        {
            get { return _current; }
            protected set { _current = value; }
        }

        private bool _disposed;
        private IObjectContext _container;

        public RepositorySession()
        {
            if (Current != null)
                throw new ApplicationException("There is already an active session, a new one cannot be created.");

            _container = Activator.CreateInstance(DefaultContainerType) as IObjectContext;
            Current = this;
        }

        public RepositorySession(IObjectContext container)
        {
            _container = container;
        }

        public IObjectContext Container
        {
            get { return _container; }
        }

        public bool LazyLoadingEnabled
        {
            get
            {
                DisposedCheck();
                return _container.ContextOptions.LazyLoadingEnabled;
            }
            set
            {
                DisposedCheck();
                _container.ContextOptions.LazyLoadingEnabled = value;
            }
        }

        public bool ProxyCreationEnabled
        {
            get
            {
                DisposedCheck();
                return _container.ContextOptions.ProxyCreationEnabled;
            }
            set
            {
                DisposedCheck();
                _container.ContextOptions.ProxyCreationEnabled = value;
            }
        }

        #region ISession Members

        public void Commit()
        {
            _container.SaveChanges();
        }

        #endregion

        private void DisposedCheck()
        {
            if (_disposed)
                throw new ObjectDisposedException(ToString());
        }

        #region IDisposable Members

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_container != null)
                    _container.Dispose();

                if (Current == this)
                    Current = null;
            }

            _disposed = true;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CassandraSession"/> class. 
        /// </summary>
        ~RepositorySession()
        {
            Dispose(false);
        }

        #endregion
    }
}