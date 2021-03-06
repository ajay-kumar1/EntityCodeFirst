﻿using MVCEntityWebDAL;
using MVCEntityWebBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEntityWebBLL
{
    public class User
    {
        private UserDb objDb;

        public User()
        {
            objDb = new UserDb();
        }

        public IEnumerable<tbl_User> GetALL()
        {
            return objDb.GetALL();
        }

        public IEnumerable<tbl_User> GetUser(string UserEmail, string Password)
        {
            return objDb.GetUser(UserEmail, Password).ToList();
        }

        public tbl_User GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_User user)
        {
            objDb.Insert(user);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_User user)
        {
            objDb.Update(user);
        }
    }
}
