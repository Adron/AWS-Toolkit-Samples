using System.Linq;
using System.Web.Mvc;
using AWS_MVC_Web_Applicaiton.Models;

namespace AWS_MVC_Web_Applicaiton.Controllers
{
    public class QuartzController : Controller
    {
        private PilesOfDataEntities db = new PilesOfDataEntities();

        public ActionResult Index()
        {
            return View(db.AwsInstanceStatus1.ToList());
        }
    }
}