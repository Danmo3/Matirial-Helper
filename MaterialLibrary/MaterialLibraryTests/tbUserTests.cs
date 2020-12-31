using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaterialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLibrary.Models.Tests
{
    [TestClass()]
    public class tbUserTests
    {
        [TestMethod]
        public void tbUserTest()
        {
            tbUser tb = new tbUser() { strTZ = "1213254", strFirstName = "fadsa", strLastName = "fds" };
            MaterialDbEntities db = new MaterialDbEntities();
            db.tbUsers.Add(tb);
            db.SaveChanges();
            
        }
    }
}