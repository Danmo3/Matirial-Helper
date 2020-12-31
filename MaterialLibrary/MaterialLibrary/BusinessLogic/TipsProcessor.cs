using MaterialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLibrary.BusinessLogic
{
    public class TipsProcessor
    {
        MaterialDbEntities MatDb = new MaterialDbEntities();

       public bool SaveTips(string tip)
        {
            
            if (!GetAllTips().Contains(tip))
            {
                MatDb.tbTips.Add(new tbTip() { strTip = tip });
                MatDb.SaveChanges();

                return true;
            }
            return false;
        }

        public string[] GetAllTips()
        {
            return MatDb.tbTips.Select(x=> x.strTip).ToArray();


        }

    }
}
