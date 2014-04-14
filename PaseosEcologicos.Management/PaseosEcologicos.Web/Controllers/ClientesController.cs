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
    public class ClientesController : Controller
    {
        private PaseosEcologicosEntities context = new PaseosEcologicosEntities();

        //
        // GET: /Clientes/

        public ViewResult Index()
        {
            return View(context.Clientes.Include(clientes => clientes.Clientes1).Include(clientes => clientes.Reservaciones).Include(clientes => clientes.Servicios_Consumidos).ToList());
        }

        //
        // GET: /Clientes/Details/5

        public ViewResult Details(int id)
        {
            Clientes clientes = context.Clientes.Single(x => x.Id == id);
            return View(clientes);
        }

        //
        // GET: /Clientes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Clientes/Create

        [HttpPost]
        public ActionResult Create(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(clientes);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(clientes);
        }
        
        //
        // GET: /Clientes/Edit/5
 
        public ActionResult Edit(int id)
        {
            Clientes clientes = context.Clientes.Single(x => x.Id == id);
            return View(clientes);
        }

        //
        // POST: /Clientes/Edit/5

        [HttpPost]
        public ActionResult Edit(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                context.Entry(clientes).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        //
        // GET: /Clientes/Delete/5
 
        public ActionResult Delete(int id)
        {
            Clientes clientes = context.Clientes.Single(x => x.Id == id);
            return View(clientes);
        }

        //
        // POST: /Clientes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = context.Clientes.Single(x => x.Id == id);
            context.Clientes.Remove(clientes);
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