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
using WebO.Models;

namespace WebM.Controllers
{
    public class DiseaseWiseReportController : Controller
    {
        private CenterGatewayDB db = new CenterGatewayDB();

        private ReportGatewayDB reportGateway = new ReportGatewayDB();

        private List<Report> reports = new List<Report>();
        public ActionResult Index()
        {
            return View(reports);
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetResult(string DiseaseId, string DateOne, string DateTwo)
        {
            reports = reportGateway.Search(DiseaseId, DateOne, DateTwo);
            //WebPageToPDF aPdf = new WebPageToPDF();
            //aPdf.WebPDF("http://localhost:3610/center");
            return Json(reports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDiseases()
        {
            var diseases = db.Diseases.ToList();
            return Json(diseases, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConvertDate(string date)
        {

            object[] dateObjects = new object[1];

            dateObjects[0] = new { Id = 1, Value = Convert.ToString(Convert.ToDateTime(date)) };

            var fullDate = dateObjects.ToList();
            return Json(fullDate, JsonRequestBehavior.AllowGet);
        }
    }
}
