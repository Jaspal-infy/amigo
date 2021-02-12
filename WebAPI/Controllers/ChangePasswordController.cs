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
    public class ChangePasswordController : Controller
    {
        // GET: api/ChangePassword
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/ChangePassword
        [HttpPost]
        public JsonResult Post([FromBody] ChangeUserPassword cup)
        {
            AmigoWalletRepository repo = new AmigoWalletRepository();

            var status = "Password not changed";
            bool returnStatus = repo.changepassword(cup.email, cup.password);

            if (returnStatus)
            {
                status = "Password changed";
            }

            return Json(status);
        }

        // PUT: api/ChangePassword/5
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
