using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.APIModel
{
    public class PlaceOrder
    {
        public string ConsumerName { get; set; }
        public int CakeID { get; set; }
        public string Quantity { get; set; }
        public string CakePrice { get; set; }
        public string TotalPrice { get; set; }
        public string PartnerEmailID { get; set; }
    }
}
