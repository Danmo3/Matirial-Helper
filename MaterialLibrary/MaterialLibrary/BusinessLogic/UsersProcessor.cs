using MaterialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLibrary.BusinessLogic
{
    public class UsersProcessor
    {
        public List<tbUser> GetAllUsers()
        {

            List<tbUser> ls = new List<tbUser>();
            MaterialDbEntities MatDb = new MaterialDbEntities();
            
            ls = qusUsers.ToList(); 
            return ls;
        }


        public void DeleteUser(string strTZ)
        {

            List<tbUser> ls = new List<tbUser>();
            MaterialDbEntities MatDb = new MaterialDbEntities();
            var v= MatDb.tbUsers.Where(x => x.strTZ == strTZ).ToList()[0];

            if (v.Mode)
            {
              int idGetOrRecive = 0;
              if (v.Classification_Id == 2)
              {
                   idGetOrRecive = MatDb.tbVolunteerInfoes.Where(x => x.Volunteer_Id == v.Id).Select(x => x.Id).ToList()[0];
                   MatDb.tbVolunteerInfoes.RemoveRange(MatDb.tbVolunteerInfoes.Where(x => x.Volunteer_Id == v.Id));
              }
              else
              {
                    idGetOrRecive = MatDb.tbSupportedInfoes.Where(x => x.Supported_Id == v.Id).Select(x => x.Id).ToList()[0];
              }
               MatDb.tbContextVolunteerSupporteds.Remove(MatDb.tbContextVolunteerSupporteds.Where(x => x.Volunteer_Id == idGetOrRecive|| x.Supported_Id == idGetOrRecive).ToList()[0]);
               MatDb.SaveChanges();
            }

            
            MatDb.tbUsers.Remove(v);
            MatDb.SaveChanges();
            
        }

        public List<tbDetail> GetDetails(int id)
        {

            List<tbDetail> ls = new List<tbDetail>();
            using (MaterialDbEntities MatDb = new MaterialDbEntities())
            {
                var qusUsers = from s in MatDb.tbDetails where id==s.Id select s;
                ls = qusUsers.ToList();
                object o= qusUsers.ToList();
            }

            
            return ls;
        }

        public tbContextVolunteerSupported[] GetSupportedAndVol(int id)
        {
            MaterialDbEntities MatDb = new MaterialDbEntities();
            return MatDb.tbContextVolunteerSupporteds.Where(x => x.tbSupportedInfo.Supported_Id == id || x.tbVolunteerInfo.Volunteer_Id == id).ToArray();
        }

        public void AscribeVolSup(int id_vol,int id_sup)
        {
            MaterialDbEntities MatDb = new MaterialDbEntities();
            int idTableVol = MatDb.tbVolunteerInfoes.Where(x => x.Volunteer_Id == id_vol).Select(x => x.Id).ToList()[0];
            int idTableSup= MatDb.tbSupportedInfoes.Where(x => x.Supported_Id == id_sup).Select(x => x.Id).ToList()[0];
            var result = MatDb.tbUsers.SingleOrDefault(b => b.Id == id_vol);
            var result2 = MatDb.tbUsers.SingleOrDefault(b => b.Id == id_sup);
            result2.Mode=result.Mode = true;
            MatDb.tbContextVolunteerSupporteds.Add(new tbContextVolunteerSupported() {Volunteer_Id= idTableVol,Supported_Id=idTableSup});
            MatDb.SaveChanges();
        }
        public void UpdateAscribeSupByVol(int id_vol, int id_sup,int id_sup_old)
        {
            MaterialDbEntities MatDb = new MaterialDbEntities();
            MatDb.tbUsers.Where(x => x.Id == id_sup_old).ToArray()[0].Mode = false;
            MatDb.tbUsers.Where(x => x.Id == id_sup).ToArray()[0].Mode = true;
            int idTableSup = MatDb.tbSupportedInfoes.Where(x => x.Supported_Id == id_sup).Select(x => x.Id).ToList()[0];
            MatDb.tbContextVolunteerSupporteds.Where(x => x.tbVolunteerInfo.Volunteer_Id == id_vol).ToArray()[0].Supported_Id = idTableSup;
            MatDb.SaveChanges();
            
        }

        

    }
}
