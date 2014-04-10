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
    public class ServiciosController : Controller
    {
        private PaseosEcologicosEntities context = new PaseosEcologicosEntities();

        //
        // GET: /Servicios/

        public ViewResult Index()
        {
            return View(context.Servicios.Include(servicios => servicios.Implementos).Include(servicios => servicios.Servicios_Consumidos).ToList());
        }

        //
        // GET: /Servicios/Details/5

        public ViewResult Details(int id)
        {
            Servicios servicios = context.Servicios.Single(x => x.Id == id);
            return View(servicios);
        }

        //
        // GET: /Servicios/Create

        public ActionResult Create()
        {

            var tipos = context.Tipos_De_Servicios;
            ViewBag.TipoId = new SelectList(tipos, "Id", "Titulo");
            return View();
        } 

        //
        // POST: /Servicios/Create

        [HttpPost]
        public ActionResult Create(Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                context.Servicios.Add(servicios);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            var tipos = context.Tipos_De_Servicios;
            ViewBag.TipoId = new SelectList(tipos, "Id", "Titulo");
            return View(servicios);
        }
        
        //
        // GET: /Servicios/Edit/5
 
        public ActionResult Edit(int id)
        {
            Servicios servicios = context.Servicios.Single(x => x.Id == id);
            var tipos = context.Tipos_De_Servicios;
            ViewBag.TipoId = new SelectList(tipos, "Id", "Titulo");
            return View(servicios);
        }

        //
        // POST: /Servicios/Edit/5

        [HttpPost]
        public ActionResult Edit(Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                context.Entry(servicios).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            var tipos = context.Tipos_De_Servicios;
            ViewBag.TipoId = new SelectList(tipos, "Id", "Titulo");
            return View(servicios);
        }

        //
        // GET: /Servicios/Delete/5
 
        public ActionResult Delete(int id)
        {
            Servicios servicios = context.Servicios.Single(x => x.Id == id);
            return View(servicios);
        }

        //
        // POST: /Servicios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios servicios = context.Servicios.Single(x => x.Id == id);
            context.Servicios.Remove(servicios);
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