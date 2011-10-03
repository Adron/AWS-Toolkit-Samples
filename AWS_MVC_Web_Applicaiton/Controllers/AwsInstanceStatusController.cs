using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using AWS_MVC_Web_Applicaiton.Models;

namespace AWS_MVC_Web_Applicaiton.Controllers
{
    public class AwsInstanceStatusController : Controller
    {
        private PilesOfDataEntities db = new PilesOfDataEntities();

        public ViewResult Index()
        {
            return View(db.AwsInstanceStatus1.ToList());
        }

        public ViewResult Details(Guid id)
        {
            AwsInstanceStatus awsinstancestatus = db.AwsInstanceStatus1.Single(a => a.Id == id);
            return View(awsinstancestatus);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AwsInstanceStatus awsinstancestatus)
        {
            if (ModelState.IsValid)
            {
                awsinstancestatus.Id = Guid.NewGuid();
                db.AwsInstanceStatus1.AddObject(awsinstancestatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(awsinstancestatus);
        }

        public ActionResult Edit(Guid id)
        {
            AwsInstanceStatus awsinstancestatus = db.AwsInstanceStatus1.Single(a => a.Id == id);
            return View(awsinstancestatus);
        }

        [HttpPost]
        public ActionResult Edit(AwsInstanceStatus awsinstancestatus)
        {
            if (ModelState.IsValid)
            {
                db.AwsInstanceStatus1.Attach(awsinstancestatus);
                db.ObjectStateManager.ChangeObjectState(awsinstancestatus, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(awsinstancestatus);
        }

        public ActionResult Delete(Guid id)
        {
            AwsInstanceStatus awsinstancestatus = db.AwsInstanceStatus1.Single(a => a.Id == id);
            return View(awsinstancestatus);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AwsInstanceStatus awsinstancestatus = db.AwsInstanceStatus1.Single(a => a.Id == id);
            db.AwsInstanceStatus1.DeleteObject(awsinstancestatus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}