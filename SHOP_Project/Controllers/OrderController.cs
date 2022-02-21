using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SHOP_Project.APIModel;
using SHOP_Project.APIModel.ReadWriteJason;
using SHOP_Project.Dataabase;
using SHOP_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderPage _service;
        public const string LoginJsonFileName = "Login.json";
        public const string PartnerJsonFileName = "Partner.json";
        public const string JsonFolderName = "Dataabase";
        public OrderController(IOrderPage Service)
        {
            _service = Service;
        }

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(PlaceOrder order)
        {
            var ID = order.PartnerEmailID;
            List<Partner> contacts = new List<Partner>();
            contacts = JsonConvert.DeserializeObject<List<Partner>>
                       (ReadWriteJson.Read(PartnerJsonFileName, JsonFolderName));
            Partner fContact = contacts.FirstOrDefault(x => x.EmailId == ID);
            if (fContact == null)
            {
                var value = "Please Register Your Credential";
                return Ok(value);
            }
            else
            {
                var data = _service.AddOrder(order);
                return Ok(data);
            }

        }
        [HttpGet]
        [Route("GetOrderList")]
        public List<PlaceOrder> GetOrderList()
        {
            List<PlaceOrder> data = new List<PlaceOrder>();
             data = _service.GetOrderHistory();
            return (data);
        }

        [HttpPost]
        [Route("GetOrderList")]
        public IActionResult GetOrderList(string EmailID)
        {         
           var   data = _service.GetOrderHistory_ByPartner_ID(EmailID);
            return Ok(data);
        }
    }
}
