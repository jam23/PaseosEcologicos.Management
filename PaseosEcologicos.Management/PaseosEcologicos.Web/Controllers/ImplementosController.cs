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
    public class ImplementosController : Controller
    {
        private PaseosEcologicosEntities context = new PaseosEcologicosEntities();

        //
        // GET: /Implementos/

        public ViewResult Index()
        {
            return View(context.Implementos.ToList());
        }

        //
        // GET: /Implementos/Details/5

        public ViewResult Details(int id)
        {
            Implementos implementos = context.Implementos.Single(x => x.Id == id);
            return View(implementos);
        }

        //
        // GET: /Implementos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Implementos/Create

        [HttpPost]
        public ActionResult Create(Implementos implementos)
        {
            if (ModelState.IsValid)
            {
                context.Implementos.Add(implementos);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(implementos);
        }
        
        //
        // GET: /Implementos/Edit/5
 
        public ActionResult Edit(int id)
        {
            Implementos implementos = context.Implementos.Single(x => x.Id == id);
            return View(implementos);
        }

        //
        // POST: /Implementos/Edit/5

        [HttpPost]
        public ActionResult Edit(Implementos implementos)
        {
            if (ModelState.IsValid)
            {
                context.Entry(implementos).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(implementos);
        }

        //
        // GET: /Implementos/Delete/5
 
        public ActionResult Delete(int id)
        {
            Implementos implementos = context.Implementos.Single(x => x.Id == id);
            return View(implementos);
        }

        //
        // POST: /Implementos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Implementos implementos = context.Implementos.Single(x => x.Id == id);
            context.Implementos.Remove(implementos);
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