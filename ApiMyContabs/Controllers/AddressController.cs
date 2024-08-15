using ApiMyContabs.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using ApiMyContabs.Repository.FormModels;
using ApiMyContabs.Repository.Entity;
using Newtonsoft.Json;

namespace ApiMyContabs.Controllers
{
    [ApiController]
    [Route("api/v1/Address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private string AddressJson = string.Empty;

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpPost]
        [Route("api/v1/Address/{SpenderId}")]
        public IActionResult GetAddressBySpenderId(int SpenderId)
        {
            try
            {
                var Request = _addressService.GetAddressBySpender(SpenderId);
                AddressJson = JsonConvert.SerializeObject(Request);

                return Ok(AddressJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   
        [HttpGet]
        [Route("api/v1/Address")]
        public IActionResult GetAllAddress()
        {
            try
            {
                var Request = _addressService.GetAllAddress();
                 AddressJson = JsonConvert.SerializeObject(Request);

                return Ok(AddressJson);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/Address/")]
        public IActionResult PutAddress([FromForm] AddressForm Address)
        {
            try
            {
                AddressJson = JsonConvert.SerializeObject(Address);
                var Request = _addressService.PutAddress(AddressJson);
                AddressJson = JsonConvert.SerializeObject(Request);

                return Ok(AddressJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
