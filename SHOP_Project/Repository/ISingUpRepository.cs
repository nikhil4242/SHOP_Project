using SHOP_Project.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
   public interface ISingUpRepository
    {
        SingUp AddSingUp(SingUp singup);
    }
}
