using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebM.Models;
using WebM.Models.Gateway;

namespace WebM.Controllers
{
    public class CenterController : Controller
    {
        private CenterGatewayDB db = new CenterGatewayDB();

        // GET: /Center/
        // SIHAM SESSION EDIT BEGIN
        public ActionResult Index()
        {
            if (Session["CenterId"] != null)
            {
                int centerId = (int)Session["CenterId"];
                return View();
            }
            else
            {
                return RedirectToAction("LoginFailed", "Logger");
            }
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

        // GET: /Center/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Center/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(string Name, string District, string Thana)
        {

            Center center = new Center();
            Random random = new Random();
            center.Name = Name;
            center.Password = Convert.ToString(random.Next(10000, 99999));
            center.District = District;
            center.Thana = Thana;
            center.Code = Name + " " + center.Thana + " " + center.District;



            if (ModelState.IsValid)
            {
                db.Centers.Add(center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(center);
        }

        // GET: /Center/Edit/5
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

        // POST: /Center/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: /Center/Delete/5
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

        // POST: /Center/Delete/5
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

        public ActionResult FindThanas(string DistrictId)
        {
            int id = Convert.ToInt32(DistrictId);

            var thanas = db.Thanas.Where(x => x.DistrictId == id).ToList();
            return Json(thanas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistrict()
        {
            var districts = db.Districts.ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CenterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CenterLogin(string centerCode, string centerPassword)
        {
            CenterLoginChekerGatewayDB aCenterLoginChekerGateway = new CenterLoginChekerGatewayDB();
            Center aCenter = aCenterLoginChekerGateway.LoginCheck(centerCode, centerPassword);
            if (aCenter.Name != null)
            {
                Session["CenterId"] = aCenter.CenterId;
                return RedirectToAction("Index", "Center");

            }
            else
            {
                return RedirectToAction("CenterLogin", "Center");
            }
        }
        //public ActionResult LoginSuccess()
        //{
        //    return View();
        //}
        //public ActionResult LoginFailed()
        //{
        //    return View();
        //}
        public ActionResult MedicineStockReport()
        {
            ReportGatewayDB aGatewayDb = new ReportGatewayDB();

            List<MedicineStock> aMedicineStocks = aGatewayDb.GetMedicineStock(1);
            return View(aMedicineStocks);
        }


    }
}
