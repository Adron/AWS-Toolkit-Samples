using System.Web.Mvc;
using AWS_MVC_Web_Application.Models;
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

        public ViewResult Index()
        {
            return View();
        }

        public JsonResult Regions()
        {
            var information = new CloudyInformation();
            return Json(information);
        }

        public JsonResult Instances(string region)
        {
            var information = new CloudyInformation();
            return Json(information);
        }
    }
}