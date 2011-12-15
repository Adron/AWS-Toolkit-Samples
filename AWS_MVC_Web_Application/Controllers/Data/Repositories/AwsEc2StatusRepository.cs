using AWS_MVC_Web_Application.Models;

namespace AWS_MVC_Web_Application.Data.Repositories
{
     public class AwsEc2StatusRepository : Repository<AwsEc2Status>
    {
        public AwsEc2StatusRepository()
            : base(RepositorySession.Current) { }

        public AwsEc2StatusRepository(IObjectContext container)
            : base(new RepositorySession(container)) { }

        public AwsEc2StatusRepository(IRepositorySession session)
            : base(session) { }
    }
}