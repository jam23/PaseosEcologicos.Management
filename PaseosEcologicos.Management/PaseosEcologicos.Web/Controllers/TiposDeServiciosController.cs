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
    public class TiposDeServiciosController : Controller
    {
        private PaseosEcologicosEntities context = new PaseosEcologicosEntities();

        //
        // GET: /TiposDeServicios/

        public ViewResult Index()
        {
            return View(context.Tipos_De_Servicios.Include(tipos_de_servicios => tipos_de_servicios.Servicios).ToList());
        }

        //
        // GET: /TiposDeServicios/Details/5

        public ViewResult Details(int id)
        {
            Tipos_De_Servicios tipos_de_servicios = context.Tipos_De_Servicios.Single(x => x.Id == id);
            return View(tipos_de_servicios);
        }

        //
        // GET: /TiposDeServicios/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TiposDeServicios/Create

        [HttpPost]
        public ActionResult Create(Tipos_De_Servicios tipos_de_servicios)
        {
            if (ModelState.IsValid)
            {
                context.Tipos_De_Servicios.Add(tipos_de_servicios);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipos_de_servicios);
        }
        
        //
        // GET: /TiposDeServicios/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tipos_De_Servicios tipos_de_servicios = context.Tipos_De_Servicios.Single(x => x.Id == id);
            return View(tipos_de_servicios);
        }

        //
        // POST: /TiposDeServicios/Edit/5

        [HttpPost]
        public ActionResult Edit(Tipos_De_Servicios tipos_de_servicios)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tipos_de_servicios).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos_de_servicios);
        }

        //
        // GET: /TiposDeServicios/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tipos_De_Servicios tipos_de_servicios = context.Tipos_De_Servicios.Single(x => x.Id == id);
            return View(tipos_de_servicios);
        }

        //
        // POST: /TiposDeServicios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_De_Servicios tipos_de_servicios = context.Tipos_De_Servicios.Single(x => x.Id == id);
            context.Tipos_De_Servicios.Remove(tipos_de_servicios);
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