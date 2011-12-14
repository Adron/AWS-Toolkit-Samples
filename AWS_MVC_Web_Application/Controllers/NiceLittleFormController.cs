using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using AWS_MVC_Web_Application.Data;
using AWS_MVC_Web_Application.Data.Repositories;
using AWS_MVC_Web_Application.Models;

namespace AWS_MVC_Web_Application.Controllers
{ 
    public class NiceLittleFormController : Controller
    {
        private readonly IRepository<NiceLittleForm> repository;

        public NiceLittleFormController()
        {
            repository = new NiceLittleFormRepository(new RepositorySession(new NotBigDataEntities()));
        }

        public NiceLittleFormController(IRepository<NiceLittleForm> repository)
        {
            this.repository = repository;
        }

       // private NotBigDataEntities db = new NotBigDataEntities();

        public ViewResult Index()
        {
            return View(repository.All().ToList());
        }

        //public ViewResult Details(Guid id)
        //{
        //    NiceLittleForm nicelittleform = db.NiceLittleForms.Single(n => n.Id == id);
        //    return View(nicelittleform);
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //} 

        //[HttpPost]
        //public ActionResult Create(NiceLittleForm nicelittleform)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        nicelittleform.Id = Guid.NewGuid();
        //        nicelittleform.Stamp = DateTime.Now;
        //        db.NiceLittleForms.AddObject(nicelittleform);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");  
        //    }

        //    return View(nicelittleform);
        //}
        
        //public ActionResult Edit(Guid id)
        //{
        //    NiceLittleForm nicelittleform = db.NiceLittleForms.Single(n => n.Id == id);
        //    return View(nicelittleform);
        //}

        //[HttpPost]
        //public ActionResult Edit(NiceLittleForm nicelittleform)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        nicelittleform.Stamp = DateTime.Now;
        //        db.NiceLittleForms.Attach(nicelittleform);
        //        db.ObjectStateManager.ChangeObjectState(nicelittleform, EntityState.Modified);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(nicelittleform);
        //}

        //public ActionResult Delete(Guid id)
        //{
        //    NiceLittleForm nicelittleform = db.NiceLittleForms.Single(n => n.Id == id);
        //    return View(nicelittleform);
        //}

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(Guid id)
        //{            
        //    NiceLittleForm nicelittleform = db.NiceLittleForms.Single(n => n.Id == id);
        //    db.NiceLittleForms.DeleteObject(nicelittleform);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}