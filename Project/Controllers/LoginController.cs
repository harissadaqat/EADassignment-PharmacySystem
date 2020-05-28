using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpPost]
        public ActionResult confirmLogin()
        {
            String email = Request["login_email"];
            String pass = Request["login_pass"];

            Model model = new Model();
            bool check = model.login(email, pass);
            String uname = model.getUser();
            String role = model.getRole();
            if (check)
            {
                Session["userName"] = uname;
                Session["flag"] = "true";
                Session["email"] = email;
                Session["password"] = pass;
                if (role.Equals("user"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Admin", "Home");
                }
                
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        [HttpGet]
        public ActionResult MyAction()
        {
            String name = Request["signup_name"];
            String email = Request["signup_mail"];
            String pass = Request["signup_password"];
            String repass = Request["signup_repass"];

            Model model = new Model();
            model.signup(name, pass, email);
            return RedirectToAction("Index", "Home");
        }
    }
}
