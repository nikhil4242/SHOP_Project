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
    public class CatalogueController : ControllerBase
    {
        private readonly ICatalogue _service;
        public CatalogueController(ICatalogue Service)
        {
            _service = Service;
        }

        [HttpPost]
        [Route("AddCatalogue")]
        public IActionResult AddCatalogue(Catalogue Catalogue)
        {
           var data = _service.addCatalogue(Catalogue);
            if(data== null)
            {
                var value = "Register the partner";
                return Ok(value);
            }
            else
            {
                return Ok(Catalogue);
            }
           
        }

        [HttpPut]
        [Route("UpdateCatalogue")]
        public Catalogue UpdateCatalogue(Catalogue Catalogue, string EmailID)
        {
            _service.UpdateCatalogue(Catalogue,EmailID);
            return (Catalogue);
        }

        [HttpDelete]
        [Route("DeleteCatalogue")]
        public void DeleteCatalogue(string EmailID)
        {
            _service.Delete(EmailID);            
           
        }

        [HttpGet]
        [Route("GetCatalogue_Id")]
        public Catalogue GetCatalogue_Id(string EmailID)
        {
           var data = _service.GetCatalogue_Id(EmailID);
            return (data);
        }

        [HttpGet]
        [Route("GetCatalogue")]
        public List<Catalogue> GetCatalogue()
        {
            var data =_service.GetCatalogue();
            return (data);
        }
    }
}
