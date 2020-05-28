using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AddToCartController : Controller
    {
        //
        // GET: /AddToCart/

        [HttpPost]
        public ActionResult AddAction()
        {
            int qty = int.Parse(Request["qty"]);
            String email = (String)Session["email"];
            String name = Request["medicine"];
            int ava = int.Parse(Request["available"]);
            Model model = new Model();
            model.insertItems(email, qty, name);
            model.updateItem(ava - qty, name);
            return RedirectToAction("Cart", "Home");

        }

    }
}
