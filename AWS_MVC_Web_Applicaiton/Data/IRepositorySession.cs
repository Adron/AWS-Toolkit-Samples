using System;

namespace AWS_MVC_Web_Applicaiton.Data
{
    public interface IRepositorySession : IDisposable
    {
        IObjectContext Container { get; }
        void Commit();
    }
}