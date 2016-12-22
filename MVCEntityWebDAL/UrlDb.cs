using MVCEntityWebBOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MVCEntityWebDAL
{
    public class UrlDb
    {

        private MVCEntityWebDBEntities db;
        public UrlDb()
        {
            db = new MVCEntityWebDBEntities();
        }
        public List<tbl_Url> GetALL()
        {
            return db.tbl_Url.ToList();
        }
        public tbl_Url GetByID(int Id)
        {
            return db.tbl_Url.Find(Id);
        }
        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_Url url = db.tbl_Url.Find(Id);
            db.tbl_Url.Remove(url);
            Save();
        }
        public void Update(tbl_Url url)
        {
            db.Entry(url).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void Save()
        {
            db.SaveChanges();
        }


    }
}
