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
    public class ReporteController : Controller
    {
        private PaseosEcologicosEntities context = new PaseosEcologicosEntities();

        //
        // GET: /Reporte/

        public ViewResult Index(string query)
        {
            var result = context.vReporteDeCosumoes.ToList();
            if (!String.IsNullOrEmpty(query))
            {
                result = result.Where(r => r.Cliente.Contains(query) || r.ReservacionId.ToString().Contains(query) || r.Representante.Contains(query)).ToList();              
            }

            return View(result);
        }

        //
        // GET: /Reporte/Details/5

        public ViewResult Details(int id)
        {
            vReporteDeCosumo vreportedecosumo = context.vReporteDeCosumoes.Single(x => x.Id == id);
            return View(vreportedecosumo);
        }

        //
        // GET: /Reporte/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Reporte/Create

        [HttpPost]
        public ActionResult Create(vReporteDeCosumo vreportedecosumo)
        {
            if (ModelState.IsValid)
            {
                context.vReporteDeCosumoes.Add(vreportedecosumo);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(vreportedecosumo);
        }
        
        //
        // GET: /Reporte/Edit/5
 
        public ActionResult Edit(int id)
        {
            vReporteDeCosumo vreportedecosumo = context.vReporteDeCosumoes.Single(x => x.Id == id);
            return View(vreportedecosumo);
        }

        //
        // POST: /Reporte/Edit/5

        [HttpPost]
        public ActionResult Edit(vReporteDeCosumo vreportedecosumo)
        {
            if (ModelState.IsValid)
            {
                context.Entry(vreportedecosumo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vreportedecosumo);
        }

        //
        // GET: /Reporte/Delete/5
 
        public ActionResult Delete(int id)
        {
            vReporteDeCosumo vreportedecosumo = context.vReporteDeCosumoes.Single(x => x.Id == id);
            return View(vreportedecosumo);
        }

        //
        // POST: /Reporte/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            vReporteDeCosumo vreportedecosumo = context.vReporteDeCosumoes.Single(x => x.Id == id);
            context.vReporteDeCosumoes.Remove(vreportedecosumo);
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