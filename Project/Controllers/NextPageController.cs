using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class NextPageController : Controller
    {
        //
        // GET: /NextPage/
        [HttpPost]
        public ActionResult Next()
        {
            int pagenum = (int)Session["pagenumber"];
            pagenum++;
            Session["pagenumber"] = pagenum;
            return RedirectToAction("Shop", "Home");
        }

        [HttpGet]
        public ActionResult Previous()
        {
            int pagenum = (int)Session["pagenumber"];
            pagenum--;
            Session["pagenumber"] = pagenum;
            return RedirectToAction("Shop", "Home");
        }

    }
}
