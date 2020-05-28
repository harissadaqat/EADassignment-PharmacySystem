using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AdminRoleController : Controller
    {
        //
        // GET: /AdminRole/

        [HttpGet]
        public ActionResult AddMedicine()
        {
            String name = Request["medicineName"];
            String add = Request["addQty"];
            String price = Request["price"];
            String img = Request["imgFile"];
            if (add.Equals(" ") || add.Equals(null) || add.Equals("null") || add.Equals(""))
                add = "0";
            if (price.Equals(" ") || price.Equals(null) || price.Equals("null") || price.Equals(""))
                price = "100";
            Model model = new Model();
            model.addMedicine(name, add, price, img);
            return RedirectToAction("Admin", "Home");
        }

        [HttpPost]
        public ActionResult UpdateMedicine()
        {
            String name = Request["medicineName"];
            String add = Request["addQty"];
            String sub = Request["subQty"];
            String price = Request["price"];
            if (add.Equals(" ") || add.Equals(null) || add.Equals("null") || add.Equals(""))
                add = "0";
            if (sub.Equals(" ") || sub.Equals(null) || sub.Equals("null") || sub.Equals(""))
                sub = "0";
            if (price.Equals(" ") || price.Equals(null) || price.Equals("null") || price.Equals(""))
                price = "100";
            int ad = int.Parse(add);
            int sb = int.Parse(sub);
            Model model = new Model();
            model.updateStock(name, ad, sb, price);
            return RedirectToAction("Admin", "Home");

        }

    }
}
