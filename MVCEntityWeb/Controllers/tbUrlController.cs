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
    public class tbUrlController : Controller
    {
        static readonly IUrlServerData RestClientUrl = new UrlServerData();
        static readonly ICategoryServerData RestClientCategory = new CategoryServerData();

        // GET: tbUrl
        public ActionResult Index()
        {
            BaseClass objBs = new BaseClass();
            //ViewBag.CategoryId = new SelectList(objBs.category.GetALL().ToList(), "CategoryId", "CategoryName");

            ViewBag.CategoryId = new SelectList(RestClientCategory.Get().ToList(), "CategoryId", "CategoryName");
            return View();
        }

    
        // GET: tbUrl/Create
        [HttpPost]
        public ActionResult Create(tbl_Url myUrl)
        {
            BaseClass objBs = new BaseClass();

            try
            {
                myUrl.IsApproved = "P";
                myUrl.UserId = 2;//objBs.user.GetALL().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;

                objBs.user.GetALL();
                if (ModelState.IsValid)
                {
                    RestClientUrl.AddUpdateDataList(myUrl);
                    //objBs.url.Insert(myUrl);

                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    //ViewBag.CategoryId = new SelectList(objBs.category.GetALL().ToList(), "CategoryId", "CategoryName");
                    ViewBag.CategoryId = new SelectList(RestClientCategory.Get().ToList(), "CategoryId", "CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
