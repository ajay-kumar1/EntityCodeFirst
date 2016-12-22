using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCEntityWebBLL;
using MVCEntityWebBOL;
namespace MVCEntityWeb.Helper
{
    public interface IUrlServerData
    {
        List<tbl_Url> Get();
        List<tbl_Url> GetByID(int ID);
        List<tbl_Url> AddUpdateDataList(tbl_Url myUrl);
        List<tbl_Url> DeleteDataList(int ID);
    }
}
