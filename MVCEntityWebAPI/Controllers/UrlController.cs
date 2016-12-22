using MVCEntityWebBLL;
using MVCEntityWebBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft;
namespace MVCEntityWebAPI.Controllers
{
    //[RoutePrefix("api/url")]
    public class UrlController : ApiController
    {

      
        //[Route("Get")]
        public List<tbl_Url> Get()
        {
            BaseClass objBs = new BaseClass();
            IEnumerable<tbl_Url> enumerable = objBs.url.GetALL();
            List<tbl_Url> asList = enumerable.ToList();
            return asList; 
        }

        public tbl_Url GetByID(int ID)
        {
            BaseClass objBs = new BaseClass();
            return objBs.url.GetByID(ID);
        }

        [HttpPost]
        //[Route("AddDataList")]
        public List<tbl_Url> AddUpdateDataList(tbl_Url myUrl)
        {
            BaseClass objBs = new BaseClass();

            try
            {
                myUrl.IsApproved = "P";
                //myUrl.UserId = objBs.user.GetALL().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                myUrl.UserId = 2;

                objBs.user.GetALL();
                if (ModelState.IsValid)
                {
                    if (myUrl.UrlId > 0)
                    {
                        objBs.url.Insert(myUrl);
                    }
                    else
                    {
                        objBs.url.Update(myUrl);
                    }
                }
            }
            catch (Exception e1)
            {   
            }
            return objBs.url.GetALL().ToList();
        }


        [HttpPost]
        //[Route("DeleteDataList")]
        public List<tbl_Url> DeleteDataList(int ID)
        {
            BaseClass objBs = new BaseClass();

            try
            {
              objBs.url.Delete(ID);
            }
            catch (Exception e1)
            {
            }
            return objBs.url.GetALL().ToList();
        }


    }
}
