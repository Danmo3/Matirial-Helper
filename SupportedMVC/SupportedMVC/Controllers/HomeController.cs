using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaterialLibrary.BusinessLogic;
using SupportedMVC.Models;
using MaterialLibrary.Models;
using System.IO;
using System.Data;

namespace SupportedMVC.Controllers
{
    public class HomeController : Controller
    {
        DataSet ds = new DataSet();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            UsersProcessor us = new UsersProcessor();
            List<tbUser> luser = us.GetAllUsers().Where(user => user.Classification_Id == 2 || user.Classification_Id == 3).ToList();
            if (luser.Count > 0)
            { 
}
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult SignUpSupported()
        {

            return View();
        }
        public ActionResult SignUp()
        {

            string[] names;
            User user = new User();

            try
            {
                names = CitiesProcessor.GetAllCities();
                Array.Sort(names);
            }
            catch
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + @"\x_Cities.xml";
                ds.ReadXml(path);
                names = GetAllCities();

                Array.Sort(names);
            }

            ViewBag.CitiesList = new SelectList(names);

            return View(user);
        }
        [HttpPost]
        //public ActionResult SignUp(User tb)
        //{
        //    int[] arr = tb.VendorAssistancesForDays.Where(x => x.Checked == true).Select(x => x.Value).ToArray();

        //    if (arr.Count() != 0 && ModelState.IsValid)
        //    {
        //        try
        //        {
        //            using (MHDbEntities MatDb = new MHDbEntities())
        //            {

        //                var qusTZ = from s in MatDb.tbUsers select s.strTZ;
        //                List<string> ls = qusTZ.ToList();
        //                if (!ls.Contains(tb.strTZ))
        //                {

        //                    tbVolunteerInfo[] iv = new tbVolunteerInfo[arr.Length];

        //                    var qusCity = MatDb.tbCities.Where(c => c.strCity == tb.strCity).Select(x => x.Id);
        //                    int id_City = qusCity.ToArray()[0];

        //                    MatDb.tbUsers.Add(new tbUser()
        //                    {
        //                        Age = tb.Age,
        //                        strTZ = tb.strTZ,
        //                        strFirstName = tb.strFirstName,
        //                        strLastName = tb.strLastName,
        //                        strEmail = tb.strEmail,
        //                        strPassword = tb.Password,
        //                        Date_Registration = DateTime.Now,
        //                        tbDetail = new tbDetail() { strPhone = tb.strPhone, strAddress = tb.strAddress, City_Id = id_City },
        //                        Classification_Id = 2
        //                    });

        //                    MatDb.SaveChanges();
        //                    var qusId = MatDb.tbUsers.Where(u => u.strTZ == tb.strTZ).Select(u => u.Id).ToList();
        //                    int vId = qusId[0];

        //                    for (int i = 0; i < arr.Length; i++)
        //                    {
        //                        iv[i] = new tbVolunteerInfo();
        //                        iv[i].Day = arr[i];
        //                        iv[i].Mode_Active = false;
        //                        iv[i].Volunteer_Id = vId;
        //                        iv[i].Active_Id = 1;
        //                        MatDb.tbVolunteerInfoes.Add(iv[i]);
        //                        MatDb.SaveChanges();
        //                    }

        //                    return View("Index");
        //                }
        //            }

        //        }
        //        catch
        //        {


        //            if (ds.Tables.Count == 0)
        //                ds.ReadXml(path);

        //            string[] results = GetAllTZUsers();

        //            if (!results.Contains(tb.strTZ))
        //            {


        //                DataRow rDetail = ds.Tables["Detail"].NewRow();

        //                string id = (from DataRow dr in ds.Tables["Detail"].Rows
        //                             select (string)dr["DetailID"]).LastOrDefault();
        //                rDetail["DetailID"] = (int.Parse(id) + 1).ToString();
        //                rDetail["Address"] = tb.strAddress;
        //                rDetail["Phone"] = tb.strPhone;
        //                rDetail["CityID"] = (from DataRow dr in ds.Tables["City"].Rows
        //                                     where (string)dr["NameCity"] == tb.strCity
        //                                     select (string)dr["CityID"]).FirstOrDefault();
        //                ds.Tables["Detail"].Rows.Add(rDetail);
        //                DataRow rUser = ds.Tables["User"].NewRow();
        //                rUser["FirstName"] = tb.strFirstName;
        //                rUser["LastName"] = tb.strLastName;
        //                rUser["Email"] = tb.strEmail;
        //                rUser["Password"] = tb.Password;
        //                rUser["ClassificationID"] = 2;
        //                rUser["Age"] = tb.Age;
        //                rUser["Registration"] = DateTime.Now;
        //                rUser["TZ"] = tb.strTZ;
        //                rUser["DetailsID"] = rDetail["DetailID"];
        //                id = (from DataRow dr in ds.Tables["User"].Rows
        //                      select (string)dr["UserID"]).LastOrDefault();
        //                rUser["UserID"] = (int.Parse(id) + 1).ToString();
        //                ds.Tables["User"].Rows.Add(rUser);



        //                for (int i = 0; i < arr.Length; i++)
        //                {
        //                    DataRow rInfoVol = ds.Tables["InfoVolunteer"].NewRow();
        //                    rInfoVol["Day"] = arr[i];
        //                    rInfoVol["ModeActive"] = 0;

        //                    rInfoVol["VolunteerID"] = rUser["UserID"];
        //                    rInfoVol["ActiveID"] = 1;
        //                    ds.Tables["InfoVolunteer"].Rows.Add(rInfoVol);
        //                }

        //                ds.WriteXml(path);
        //                return View("Index");
        //            }

        //        }


        //    }
        //    return RedirectToAction("SignUp");
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string[] GetAllCities()
        {

            return (from row in ds.Tables["City"].AsEnumerable()
                    select row.Field<string>("NameCity")).ToArray();

        }

        public string[] GetAllTZUsers()
        {

            return (from row in ds.Tables["User"].AsEnumerable()
                    select row.Field<string>("TZ")).ToArray();

        }

    }
}