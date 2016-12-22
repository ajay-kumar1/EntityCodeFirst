using System;
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
    public class CategoryController : ApiController
    {

        //[Route("Get")]
        public List<tbl_Category> Get()
        {
            BaseClass objBs = new BaseClass();
            IEnumerable<tbl_Category> enumerable = objBs.category.GetALL();
            List<tbl_Category> asList = enumerable.ToList();
            return asList;
        }

        public tbl_Category GetByID(int ID)
        {
            BaseClass objBs = new BaseClass();
            return objBs.category.GetByID(ID); 
        }

        [HttpPost]
        //[Route("AddDataList")]
        public List<tbl_Category> AddUpdateDataList(tbl_Category myCategory)
        {
            BaseClass objBs = new BaseClass();

            try
            {
                objBs.user.GetALL();
                if (ModelState.IsValid)
                {
                    if (myCategory.CategoryId > 0)
                    {
                        objBs.category.Insert(myCategory);
                    }
                    else
                    {
                        objBs.category.Update(myCategory);
                    }
                }
            }
            catch (Exception e1)
            {
            }
            return objBs.category.GetALL().ToList();
        }


        [HttpPost]
        //[Route("DeleteDataList")]
        public List<tbl_Category> DeleteDataList(int ID)
        {
            BaseClass objBs = new BaseClass();

            try
            {
                objBs.url.Delete(ID);
            }
            catch (Exception e1)
            {
            }
            return objBs.category.GetALL().ToList();
        }


    }
}