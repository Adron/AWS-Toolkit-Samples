using System.Web.Mvc;
using Amazon;
using Noctilucent;

namespace AWS_MVC_Web_Application.Controllers
{
    public class AmazonWebServicesController : Controller
    {
        private readonly IPyrocumulus _pyrocumulus;
        
        public AmazonWebServicesController()
        {
            _pyrocumulus = new Pyrocumulus();
        }

        public AmazonWebServicesController(IPyrocumulus pyrocumulus)
        {
            _pyrocumulus = pyrocumulus;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
