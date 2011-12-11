using System.Web.Mvc;
using AWS_MVC_Web_Applicaiton.Data;
using AWS_MVC_Web_Applicaiton.Data.Repositories;
using AWS_MVC_Web_Applicaiton.Models;

namespace AWS_MVC_Web_Applicaiton.Controllers
{
    public class QuartzController : Controller
    {
        readonly IRepository<AwsEc2Status> repository;

        public QuartzController()
        {
            repository = new AwsEc2StatusRepository(new RepositorySession(new PilesOfDataEntities()));
        }

        public QuartzController(IRepository<AwsEc2Status> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            using (new RepositorySession())
            {
                var result = repository.All();
                return View(result);
            }
        }
    }
}