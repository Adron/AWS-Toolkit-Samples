using System.Web.Mvc;
using AWS_MVC_Web_Applicaiton.Data;
using AWS_MVC_Web_Applicaiton.Data.Repositories;

namespace AWS_MVC_Web_Applicaiton.Controllers
{
    public class QuartzController : Controller
    {
        public ViewResult Index()
        {
            using (new RepositorySession())
            {
                var repo = new AwsEc2StatusRepository();
                var result = repo.GetAll();
                return View(result);
            }
        }
    }
}