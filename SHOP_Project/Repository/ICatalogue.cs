using SHOP_Project.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
   public interface ICatalogue
    {
        Catalogue addCatalogue(Catalogue catalogue);
        Catalogue UpdateCatalogue(Catalogue catalogue, string EmailID);
       void Delete(string EmailID);
        Catalogue GetCatalogue_Id(string EmailId);
        List<Catalogue> GetCatalogue();

    }
}
