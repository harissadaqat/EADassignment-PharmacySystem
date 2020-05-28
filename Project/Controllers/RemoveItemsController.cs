using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class RemoveItemsController : Controller
    {
        //
        // GET: /RemoveItems/
        [HttpPost]
        public ActionResult MyAction()
        {
            Model model = new Model();
            String email = (String)Session["email"];
            String str = Request["indexes"];
            model.prepareRemovingItems(email);
            for (int i = 0; i < str.Length; i++)
            {
                int index = int.Parse(char.ToString(str.ElementAt(i)));
                model.removeItems(index);
            }
            return RedirectToAction("Cart", "Home");
        }
        [HttpGet]
        public ActionResult MyOtherAction()
        {
            Model model = new Model();
            String email = (String)Session["email"];
            model.prepareRemovingItems(email);
            model.removeAllItems();

            return RedirectToAction("Thankyou", "Home");
        }
    }
}
