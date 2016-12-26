
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCEntityWebBLL;
using MVCEntityWebBOL;
namespace MVCEntityWeb.Helper
{
    public interface ILoginServerData
    {
     
        List<tbl_User> GetUser(string UserName, string Password);
    }
}

