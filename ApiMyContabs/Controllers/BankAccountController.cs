using ApiMyContabs.Repository.Entity;
using ApiMyContabs.Repository.FormModels;
using ApiMyContabs.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiMyContabs.Controllers
{
    [ApiController]
    [Route("api/v1/BankAccount")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService = new BankAccountService();
        private string BankAccountJson = string.Empty;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [HttpPost]
        [Route("api/v1/GetBankAccount")]
        public IActionResult GetBankAccount([FromForm] BankAccountForm BankAccountForm)
        {
            try
            {
                var Request = _bankAccountService.GetBankAccount(BankAccountForm);
                BankAccountJson = JsonConvert.SerializeObject(Request);
                return Ok(Request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/v1/PutBankAccount")]
        public IActionResult Put([FromForm] BankAccountForm BankAccountForm)
        {
            try
            {
                var Request = _bankAccountService.PutBankAccount(BankAccountForm);
                BankAccountJson = JsonConvert.SerializeObject(Request);
                return Ok(Request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
