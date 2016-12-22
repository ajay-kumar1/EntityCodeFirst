﻿using MVCEntityWebDAL;
using MVCEntityWebBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEntityWebBLL
{
    public class Url
    {
        private UrlDb objDb;

        public Url()
        {
            objDb = new UrlDb();
        }

        public IEnumerable<tbl_Url> GetALL()
        {
            return objDb.GetALL();
        }

        public tbl_Url GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_Url url)
        {
            objDb.Insert(url);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_Url url)
        {
            objDb.Update(url);
        }
    }
}
