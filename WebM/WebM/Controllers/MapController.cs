using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebM.Models;
using WebM.Models.Gateway;

namespace WebM.Controllers
{
    public class MapController : Controller
    {
        private CenterGatewayDB db = new CenterGatewayDB();

        private ReportGatewayDB reportGateway = new ReportGatewayDB();

        public ActionResult Index()
        {




            return View();
        }

        public ActionResult GetResult(string diseaseName, string dateOne, string dateTwo)
        {
            List<long> TotalEffectedPeople = new List<long>();
            TotalEffectedPeople = reportGateway.SearchMapData(diseaseName, dateOne, dateTwo);


            return View(TotalEffectedPeople);
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