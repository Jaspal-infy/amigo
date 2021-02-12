using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using DataAccessLayer;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : Controller
    {
        // GET: api/ForgotPassword
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST: api/ForgotPassword
        [HttpPost]
        public JsonResult Post([FromBody] ForgotPassword fp)
        {
            AmigoWalletRepository repo = new AmigoWalletRepository();
            string results = repo.forgotpassword(fp.email);
            string returnResult = "otp: " + results;
            return Json(returnResult);
        }

        // PUT: api/ForgotPassword/5
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
