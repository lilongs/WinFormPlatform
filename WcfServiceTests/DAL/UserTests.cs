using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DAL.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void InsertUser()
        {
            string colname = "sysuser";
            User user = new User();
            user.username = "lilong";
            user.password = "123";
            user.InsertUser(colname, user);
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            string colname = "sysuser";
            User user = new User();
            user.DeleteOneUser(colname, "lilong");
        }

        [TestMethod()]
        public void SelectUserTest()
        {
            string colname = "sysuser";
            User user = new User();
            List<User> list=user.SelectUser(colname, string.Empty);
        }
    }
}