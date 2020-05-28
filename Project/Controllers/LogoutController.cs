using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LogoutController : Controller
    {
        //
        // GET: /Logout/
        [HttpPost]
        public ActionResult confirmLogout()
        {
            Session["userName"] = null;
            Session["flag"] = "false";
            Session["email"] = null;
            Session["password"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DeleteMedicine()
        {
            String name = Request["medicineName"];
            Model model = new Model();
            model.removeMedicine(name);
            return RedirectToAction("Admin", "Home");
        }

    }
}
