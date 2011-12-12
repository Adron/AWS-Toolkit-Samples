using System;

namespace AWS_MVC_Web_Application.Data
{
    public interface IRepositorySession : IDisposable
    {
        IObjectContext Container { get; }
        void Commit();
    }
}