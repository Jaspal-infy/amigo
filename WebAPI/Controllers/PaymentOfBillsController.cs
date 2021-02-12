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
    public class PaymentOfBillsController : Controller
    {
        // GET: api/PaymentOfBills
        [HttpGet]
        public JsonResult Get()
        {
            AmigoWalletRepository repo = new AmigoWalletRepository();

            return Json(repo.merchantName());
        }


        // POST: api/PaymentOfBills
        [HttpPost]
        public JsonResult Post([FromBody] PaymentBill pb)
        {
            AmigoWalletRepository repo = new AmigoWalletRepository();
            string res = repo.paymentOfBills(pb.email, pb.payment, pb.merchantName);
            return Json(res);
        }

        // PUT: api/PaymentOfBills/5
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
