﻿using ApiMyContabs.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMyContabs.Controllers
{
    [ApiController]
    [Route("api/v1/Address")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService = new AddressService();

        [HttpPost]
        [Route("api/v1/Address/{SpenderId}")]
        public IActionResult GetAddressBySpenderId(int SpenderId)
        {
            string? Request = _addressService.GetAddressBySpender(SpenderId);
            return Ok(Request);
        }

        [HttpGet]
        [Route("api/v1/Address")]

        public IActionResult GetAllAddress()
        {
            string? Request = _addressService.GetAllAddress();
            return Ok(Request);
        }
    }
}
