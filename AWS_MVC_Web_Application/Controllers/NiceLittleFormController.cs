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

        public ViewResult Index()
        {
            return View(repository.All().ToList());
        }

        //public ViewResult Details(Guid id)
        //{
        //    NiceLittleForm nicelittleform = db.NiceLittleForms.Single(n => n.Id == id);
        //    return View(nicelittleform);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NiceLittleForm nicelittleform)
        {
            using (var db = new RepositorySession())
            {
                if (ModelState.IsValid)
                {
                    nicelittleform.Id = Guid.NewGuid();
                    nicelittleform.Stamp = DateTime.Now;
                    repository.Add(nicelittleform);
                    db.Commit();
                }
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
            var niceLittleForm = repository.All().Single(n => n.Id == id);
            return View(niceLittleForm);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var repoResult = repository.All();
            var nicelittleform = repoResult.Single(n => n.Id == id);

            using (var db = new RepositorySession())
            {
                repository.Delete(nicelittleform);
                db.Commit();
            }

            return RedirectToAction("Index");
        }
    }
}