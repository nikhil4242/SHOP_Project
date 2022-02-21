using SHOP_Project.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
   public interface IPartnerRepository
    {
        Partner AddPartner(Partner partner);
        List<Partner> GetPartner();
        Partner GetPartnerById(string ID);

    }
}
