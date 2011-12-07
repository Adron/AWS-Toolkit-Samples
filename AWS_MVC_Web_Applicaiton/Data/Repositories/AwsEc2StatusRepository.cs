using System;
using System.Collections.Generic;
using System.Linq;
using AWS_MVC_Web_Applicaiton.Models;

namespace AWS_MVC_Web_Applicaiton.Data.Repositories
{
     public class AwsEc2StatusRepository : Repository<AwsEc2Status>
    {
        public AwsEc2StatusRepository()
            : base(RepositorySession.Current) { }

        public AwsEc2StatusRepository(IObjectContext container)
            : base(new RepositorySession(container)) { }

        public AwsEc2StatusRepository(IRepositorySession session)
            : base(session) { }

        public AwsEc2Status Get(Guid id)
        {
            return Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<AwsEc2Status> GetAll()
        {
            return All().ToList();
        }
    }
}