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
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerRepository _service;
        public PartnerController(IPartnerRepository Service)
        {           
            _service = Service;
        }

        [HttpPost]
        [Route("AddPartner")]
        public Partner AddPartner(Partner partner)
        {
            _service.AddPartner(partner);
            return (partner);
        }

        [HttpGet]
        [Route("GetPartner")]
        public List<Partner> GetPartner()
        {
            List<Partner> data = new List<Partner>();
            data =  _service.GetPartner();
            return(data) ;
        }

        [HttpGet]
        [Route("GetPartner_ID")]
        public Partner GetPartner_ID(string ID)
        {
            var data = _service.GetPartnerById(ID);
            return (data);
        }
    }
}
