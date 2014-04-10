using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaseosEcologicos.Model;

namespace PaseosEcologicos.Web.Controllers
{   
    public class PaseosController : Controller
    {
        private PaseosEcologicosEntities context = new PaseosEcologicosEntities();

        //
        // GET: /Paseos/

        public ViewResult Index()
        {
            return View(context.Paseos.Include(paseos => paseos.Reservaciones).ToList());
        }

        //
        // GET: /Paseos/Details/5

        public ViewResult Details(int id)
        {
            Paseos paseos = context.Paseos.Single(x => x.Id == id);
            return View(paseos);
        }

        //
        // GET: /Paseos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Paseos/Create

        [HttpPost]
        public ActionResult Create(Paseos paseos)
        {
            if (ModelState.IsValid)
            {
                context.Paseos.Add(paseos);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(paseos);
        }
        
        //
        // GET: /Paseos/Edit/5
 
        public ActionResult Edit(int id)
        {
            Paseos paseos = context.Paseos.Single(x => x.Id == id);
            return View(paseos);
        }

        //
        // POST: /Paseos/Edit/5

        [HttpPost]
        public ActionResult Edit(Paseos paseos)
        {
            if (ModelState.IsValid)
            {
                context.Entry(paseos).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paseos);
        }

        //
        // GET: /Paseos/Delete/5
 
        public ActionResult Delete(int id)
        {
            Paseos paseos = context.Paseos.Single(x => x.Id == id);
            return View(paseos);
        }

        //
        // POST: /Paseos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Paseos paseos = context.Paseos.Single(x => x.Id == id);
            context.Paseos.Remove(paseos);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}