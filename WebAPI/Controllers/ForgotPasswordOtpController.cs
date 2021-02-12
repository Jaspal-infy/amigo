using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordOtpController : Controller
    {
        // GET: api/ForgotPasswordOtp
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST: api/ForgotPasswordOtp
        [HttpPost]
        public JsonResult Post([FromBody] ForgotPassword fpOtp)
        {
            AmigoWalletRepository repo = new AmigoWalletRepository();

            string results = repo.givePasswordOtp(fpOtp.email, fpOtp.otp);
            return Json(results);
        }

        // PUT: api/ForgotPasswordOtp/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
