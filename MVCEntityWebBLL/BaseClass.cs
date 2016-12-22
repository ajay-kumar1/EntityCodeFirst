using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEntityWebBLL
{
   
     public class BaseClass
    {
        public Category category { get; set; }
        public User user { get; set; }
        public Url url { get; set; }
        public BaseClass()
        {
            category = new Category();
            user = new User();
            url = new Url();
        }
    }
}
