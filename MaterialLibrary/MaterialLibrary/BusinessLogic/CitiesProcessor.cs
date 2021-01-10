using MaterialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaterialLibrary.BusinessLogic
{
   public static class CitiesProcessor
    {
       public static string[] GetAllCities()
        {
            string[] names;

            MaterialDbEntities MatDb = new MaterialDbEntities();
          var qusCities = from s in MatDb.tbCities select s.strCity;
          names = qusCities.ToArray();
       

            return names;
        }
    }
}
