using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        [HttpGet("{id:long}")]   
        public Task<Customer> GetCustomerAsync([FromRoute] long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]   
        public Task<long> CreateCustomerAsync([FromBody] Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}