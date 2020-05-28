using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ShopSingleController : Controller
    {
        //
        // GET: /ShopSingle/
        [HttpPost]
        public ActionResult Single()
        {
            String index = Request["indexx"];
            Session["medicineIndex"] = int.Parse(index);
            return RedirectToAction("ShopSingle", "Home");
        }

    }
}
