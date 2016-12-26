using MVCEntityWebBOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEntityWebDAL
{
    public class UserDb
    {
        private MVCEntityWebDBEntities db;
        public UserDb()
        {
            db = new MVCEntityWebDBEntities();
        }

        //var Result = Db.GeneralSettings.Where(Row => Row.ShortUrl == Name & Row.UserId != UserId).ToList();

        public IEnumerable<tbl_User> GetUser(string UserEmail, string Password)
        {
            return db.tbl_User.Where(Row => Row.UserEmail == UserEmail & Row.Password != Password).ToList();
        }
        public IEnumerable<tbl_User> GetALL()
        {
            return db.tbl_User.ToList();
        }
        public tbl_User GetByID(int Id)
        {
            return db.tbl_User.Find(Id);
        }
        public void Insert(tbl_User user)
        {
            db.tbl_User.Add(user);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_User user = db.tbl_User.Find(Id);
            db.tbl_User.Remove(user);
            Save();
        }
        public void Update(tbl_User user)
        {
            db.Entry(user).State = EntityState.Modified;
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
