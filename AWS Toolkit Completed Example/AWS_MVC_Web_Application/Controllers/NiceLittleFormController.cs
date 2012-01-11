using System;
using System.Linq;
using System.Web.Mvc;
using AWS_MVC_Web_Application.Data;
using AWS_MVC_Web_Application.Data.Repositories;
using AWS_MVC_Web_Application.Models;

namespace AWS_MVC_Web_Application.Controllers
{
    public class NiceLittleFormController : Controller
    {
        private IRepository<NiceLittleForm> repository;
        private IRepositorySession workingDatabaseSession;

        public NiceLittleFormController()
        {
            workingDatabaseSession = new RepositorySession(new NotBigDataEntities());
            repository = new NiceLittleFormRepository(workingDatabaseSession);
        }

        public NiceLittleFormController(IRepository<NiceLittleForm> repository, IRepositorySession workingSession)
        {
            workingDatabaseSession = workingSession;
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.All().ToList());
        }

        public ViewResult Details(Guid id)
        {
            return View(repository.All().Single(n => n.Id == id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NiceLittleForm nicelittleform)
        {
            if (ModelState.IsValid)
            {
                nicelittleform.Id = Guid.NewGuid();
                nicelittleform.Stamp = DateTime.Now;
                repository.Add(nicelittleform);
                workingDatabaseSession.Commit();
            }

            return View(nicelittleform);
        }

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

        public ActionResult Delete(Guid id)
        {
            return View(repository.All().Single(n => n.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            using (var db = new RepositorySession())
            {
                var niceLittleform = repository.All().Single(n => n.Id == id);
                repository.Delete(niceLittleform);
                db.Commit();
            }

            return RedirectToAction("Index");
        }
    }
}