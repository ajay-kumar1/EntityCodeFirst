using MVCEntityWebBLL;
using MVCEntityWebBOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVCEntityWebAPI.Controllers
{
    public class LoginController : ApiController
    {
        public List<tbl_User> GetUser(string UserName, string Password)
        {
            BaseClass objBs = new BaseClass();
            IEnumerable<tbl_User> enumerable = objBs.user.GetUser(UserName, Password);
            List<tbl_User> asList = enumerable.ToList();
            return asList;
        }

    }
}
