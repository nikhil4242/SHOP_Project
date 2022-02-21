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
    public class LoginController : ControllerBase
    {
        private readonly DatabaseSetting dbContext;
        private readonly ILoginRepository _service;
        public const string LoginJsonFileName = "Login.json";
        public const string SingUpJsonFileName = "SingUP.json";
        public const string JsonFolderName = "Dataabase";
        public LoginController( DatabaseSetting db, ILoginRepository Service)
        {
            dbContext = db;
            _service = Service;
        }

        
        [HttpPost]
        [Route("GetLogin")]       
        public IActionResult GetLogin(Login login)
        {
            List<SingUp> contacts = new List<SingUp>();
            contacts = JsonConvert.DeserializeObject<List<SingUp>>
                       (ReadWriteJson.Read(SingUpJsonFileName, JsonFolderName));
            SingUp fContact = contacts.FirstOrDefault(x => x.EmailID == login.UserEmailID);
            if (fContact == null)
            {
                var value = "Please Register Your Credential";
                return Ok(value);
            }
            else if (login.Password == fContact.Password && login.UserEmailID == fContact.EmailID)
            {
                var value = "USER LOGIN IS CORRECT";
                return Ok(value);
            }
            else
            {
                var VALUE = "INCOMPLETE USER DETAILS";
                return Ok(VALUE);
            }
        }
    }
}
