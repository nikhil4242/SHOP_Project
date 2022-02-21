using Microsoft.AspNetCore.Mvc;
using SHOP_Project.APIModel;
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
    public class SingUpController : ControllerBase
    {
        private readonly DatabaseSetting dbContext;
        private readonly ISingUpRepository _service;
        public SingUpController(DatabaseSetting db, ISingUpRepository Service)
        {
            dbContext = db;
            _service = Service;
        }

        [HttpPost]
        [Route("AddSingUp")]
        public SingUp AddSingUp(SingUp Singup)
        {
             _service.AddSingUp(Singup);         
            return (Singup);
        }
    }
}
