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

namespace WebM.Controllers
{
    public class SendMedicineController : Controller
    {
        private CenterGatewayDB db = new CenterGatewayDB();
        private SendMedicineDB mdb = new SendMedicineDB();


        public ActionResult Index()
        {
            return View(db.Centers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(List<CenterMedicine> medicines)
        {

            foreach (CenterMedicine aCenterMedicine in medicines)
            {
                CenterMedicine centerMedicine = new CenterMedicine();
                CenterMedicine centerMedicineO = new CenterMedicine();
                centerMedicine.MedicineId = mdb.FindMedicineId(aCenterMedicine.MedicineId);
                centerMedicine.CenterId = mdb.FindCenterId(aCenterMedicine.CenterId);

                const int NULL = 0;
                if (centerMedicine.MedicineId != NULL && centerMedicine.CenterId != NULL)
                {


                    centerMedicineO.MedicineQuantity = mdb.FindQuantity(aCenterMedicine);
                    aCenterMedicine.MedicineQuantity = centerMedicineO.MedicineQuantity + aCenterMedicine.MedicineQuantity;
                    mdb.UpdateData(aCenterMedicine);

                }
                else
                {
                    db.CenterMedicines.Add(aCenterMedicine);
                    db.SaveChanges();
                }
                centerMedicine = null;

            }

            return View("Create");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterId,Name,Password,District,Thana")] Center center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(center);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Center center = db.Centers.Find(id);
            db.Centers.Remove(center);
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
        public ActionResult GetDistrict()
        {
            var districts = db.Districts.ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindThanas(string DistrictId)
        {
            int id = Convert.ToInt32(DistrictId);

            var thanas = db.Thanas.Where(x => x.DistrictId == id).ToList();
            return Json(thanas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindCenter(string Thana)
        {


            var thanas = db.Centers.Where(x => x.Thana.Equals(Thana)).ToList();
            return Json(thanas, JsonRequestBehavior.AllowGet);
        }




        public ActionResult GetMedicine()
        {
            var districts = db.Medicines.ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }
    }
}
