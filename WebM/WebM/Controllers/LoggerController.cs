using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebM.Controllers
{
    public class LoggerController : Controller
    {
        //
        // GET: /Logger/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginFailed()
        {
            return View();
        }
	}
}