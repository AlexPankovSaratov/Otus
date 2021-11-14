using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private ApplicationDBContext _context;

        public CustomerController(ApplicationDBContext context)
		{
            _context = context;
        }
        [HttpGet("{id:long}")]   
        public ActionResult<Customer> GetCustomerAsync([FromRoute] long id)
        {
            var Customer = _context.Customers.FindAsync(id).Result;
            if (Customer == null) return NotFound();
            return new ActionResult<Customer>(Customer);
        }

        [HttpPost("")]   
        public ActionResult<long> CreateCustomerAsync([FromBody] Customer customer)
        {
			if (customer.Id != 0)
			{
                var Customer = _context.Customers.FindAsync(customer.Id).Result;
				if (Customer != null)
				{
                    return Conflict();
                }
            }
            long id = _context.Customers.AddAsync(customer).Result.Entity.Id;
            _context.SaveChangesAsync();
            return new ActionResult<long>(id);
        }
    }
}