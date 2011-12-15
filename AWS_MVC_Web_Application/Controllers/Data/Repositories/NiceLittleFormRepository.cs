using AWS_MVC_Web_Application.Models;

namespace AWS_MVC_Web_Application.Data.Repositories
{
    public class NiceLittleFormRepository : Repository<NiceLittleForm>
    {
        public NiceLittleFormRepository()
            : base(RepositorySession.Current) { }

        public NiceLittleFormRepository(IObjectContext container)
            : base(new RepositorySession(container)) { }

        public NiceLittleFormRepository(IRepositorySession session)
            : base(session) { }
    }
}