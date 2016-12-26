using MVCEntityWebBLL;
using MVCEntityWebBOL;
using MVCEntityWeb.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCEntityWeb.Controllers
{
    public class LoginController : Controller
    {

        static readonly ILoginServerData RestClientLogin = new LoginServerData();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(tbl_User model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

             var result = RestClientLogin.GetUser(model.UserEmail, model.Password);

             return View("Index");
        }
    }
}