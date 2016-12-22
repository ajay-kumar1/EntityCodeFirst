using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCEntityWebBLL;
using MVCEntityWebBOL;
namespace MVCEntityWeb.Helper
{
    public interface ICategoryServerData
    {

        List<tbl_Category> Get();
        List<tbl_Category> GetByID(int ID);
        List<tbl_Category> AddUpdateDataList(tbl_Category myCategory);
        List<tbl_Category> DeleteDataList(int ID);
    }
}
