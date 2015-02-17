using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebM.Models;
using WebM.Models.Gateway;

namespace WebM.Controllers
{
    public class ChartController : Controller
    {
        private CenterGatewayDB db = new CenterGatewayDB();
        ChartDataGateWay aGateWay = new ChartDataGateWay();
        private ReportGatewayDB reportGateway = new ReportGatewayDB();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ShowChartFromDB(string districtName, string dateOne, string dateTwo)
        {
            Session["DistrictId"] = districtName;
            Session["dateOne"] = dateOne;
            Session["dateTwo"] = dateTwo;



            return View();
        }

        public ActionResult CreateBar()
        {
            string DistrictId = (string)Session["DistrictId"];
            string dateOne = (string)Session["dateOne"];
            string dateTwo = (string)Session["dateTwo"];

            List<string> _xVal = new List<string>();
            List<string> _yVal = new List<string>();
            List<ChartData> chartDatas = aGateWay.GetAllData(DistrictId, dateOne, dateTwo);


            foreach (ChartData aChartData in chartDatas)
            {
                _xVal.Add(aChartData.DiseaseName);
                _yVal.Add(aChartData.EffectedPeople.ToString());
            }
            string[] _xval = _xVal.ToArray();
            string[] _yval = _yVal.ToArray();

            var myChart = new Chart(width: 600, height: 300)
            .AddTitle("Disease and Effected People Bar Diagram")
            .AddSeries(
                 xValue: _xval,
                 yValues: _yval)
                .GetBytes("png");
            return File(myChart, "image/png");

        }

        public ActionResult GetResult(string DistrictId, string dateOne, string dateTwo)
        {
            List<long> TotalEffectedPeople = new List<long>();
            TotalEffectedPeople = reportGateway.SearchMapData(DistrictId, dateOne, dateTwo);


            return View(TotalEffectedPeople);
        }


        public ActionResult GetDistrict()
        {
            var districts = db.Districts.ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
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