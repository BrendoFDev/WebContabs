using ApiMyContabs.Repository.FormModels;
using ApiMyContabs.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiMyContabs.Controllers
{
    public class SpenderController : ControllerBase
    {
        private readonly ISpenderService _spenderService = new SpenderService();
        private string SpenderJson = string.Empty;
        
        public SpenderController(ISpenderService spenderService)
        {
            this._spenderService = spenderService;
        }


        [HttpGet]
        [Route("api/v1/Spender")]
        public IActionResult GetSpenderById([FromForm] int SpenderId)
        {
            try
            {
                var Request = _spenderService.GetSpenderById(SpenderId);
                SpenderJson = JsonConvert.SerializeObject(Request);
                return Ok(SpenderJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/v1/GetSpender")]
        public IActionResult GetSpender([FromForm] SpenderForm Spender)
        {
            try
            {
                Spender.Id = Spender.Id != null ? Spender.Id : 0;
                var Request = _spenderService.GetSpender(Spender);

                SpenderJson = JsonConvert.SerializeObject(Request);

                return Ok(SpenderJson);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/PutSpender")]
        public IActionResult PutSpender([FromForm] SpenderForm Spender)
        {
            try
            {
                var Request = _spenderService.PutSpender(Spender);
                SpenderJson = JsonConvert.SerializeObject(Request);
                return Ok(SpenderJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
