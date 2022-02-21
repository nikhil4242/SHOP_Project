using Newtonsoft.Json;
using SHOP_Project.APIModel;
using SHOP_Project.APIModel.ReadWriteJason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Repository
{
    public class OrderRepository : IOrderPage
    {
        public const string OrderHistoryFileName = "OrderHistory.json";
        public const string CatalogueJsonFileName = "Catalogue.json";
        public const string JsonFolderName = "Dataabase";
        public const string PartnerJsonFileName = "Partner.json";
        public PlaceOrder AddOrder(PlaceOrder order)
        {
            List<PlaceOrder> PlaceOrders = new List<PlaceOrder>();

            PlaceOrders = JsonConvert.DeserializeObject<List<PlaceOrder>>
                       (ReadWriteJson.Read(OrderHistoryFileName, JsonFolderName));
            if (PlaceOrders != null)
            {
                PlaceOrders.Add(order);
                string jSONString = JsonConvert.SerializeObject(PlaceOrders);
                ReadWriteJson.Write(PartnerJsonFileName, jSONString);
            }
            else
            {
                string jSONStrings = JsonConvert.SerializeObject(order);
                ReadWriteJson.Write(PartnerJsonFileName, jSONStrings);
            }   
            return (order);
        }

        public List<PlaceOrder> GetOrderHistory()
        {
            List<PlaceOrder> order = new List<PlaceOrder>();
            order = JsonConvert.DeserializeObject<List<PlaceOrder>>
                       (ReadWriteJson.Read(OrderHistoryFileName, JsonFolderName));
            return (order);
        }

        public PlaceOrder GetOrderHistory_ByPartner_ID(string EmailId)
        {
            List<PlaceOrder> order = new List<PlaceOrder>();
            order = JsonConvert.DeserializeObject<List<PlaceOrder>>
                       (ReadWriteJson.Read(OrderHistoryFileName, JsonFolderName));

            PlaceOrder fContact = order.FirstOrDefault(x => x.PartnerEmailID == EmailId);
            return (fContact);

        }
    }
}
