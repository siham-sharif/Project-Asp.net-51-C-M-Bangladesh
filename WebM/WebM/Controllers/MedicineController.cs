using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebM.Models;
using WebM.Models.Gateway;
using WebM.Models.GatewayDB;

namespace WebM.Controllers
{
    public class MedicineController : Controller
    {
        private CenterGatewayDB db = new CenterGatewayDB();

        // GET: /Medicine/
        public ActionResult Index()
        {
            return View(db.Medicines.ToList());
        }

        // GET: /Medicine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: /Medicine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Medicine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(string GenericName, string Quantity, string UnitQuantity)
        {
            Medicine medicine = new Medicine();
            medicine.GenericName = GenericName;
            medicine.Quantity = Convert.ToInt32(Quantity);
            medicine.QuantityUnit = UnitQuantity;

            if (ModelState.IsValid)
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicine);
        }

        // GET: /Medicine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: /Medicine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineId,GenericName,Quantity,QuantityUnit")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        // GET: /Medicine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: /Medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            db.Medicines.Remove(medicine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetUnit()
        {
            object[] dataObjects = new object[2];

            dataObjects[0] = new { Id = 1, Value = "mg" };
            dataObjects[1] = new { Id = 2, Value = "ml" };

            var fullData = dataObjects.ToList();
            return Json(fullData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckUnique(string GenericName, string Quantity, string UnitQuantity)
        {
            object[] dataObjects = new object[1];

            MedicineGatewayDB aGateway = new MedicineGatewayDB();
            if (aGateway.CheckUnique(GenericName, Quantity, UnitQuantity).Equals("false"))
            {
                dataObjects[0] = new { Id = 1, Value = "false" };
            }
            else
            {
                dataObjects[0] = new { Id = 1, Value = "true" };
            }
            var fullData = dataObjects.ToList();
            return Json(fullData, JsonRequestBehavior.AllowGet);
        }
    }
}
