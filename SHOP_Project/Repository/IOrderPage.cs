using SHOP_Project.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
   public interface IOrderPage
    {
        PlaceOrder AddOrder(PlaceOrder order);
        List<PlaceOrder> GetOrderHistory();
        PlaceOrder GetOrderHistory_ByPartner_ID(string EmailId);
    }
}
