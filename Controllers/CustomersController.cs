using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationApi.Model;
using NotificationApi.Repository;
using NotificationApi.Data;


namespace NotificationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly NotificationApiDbcontext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationRepository _notificationRepository;

        public CustomersController(NotificationApiDbcontext context,
            ICustomerRepository customerRepository,
            INotificationRepository notificationrepository)
        {

            _customerRepository = customerRepository;
            _notificationRepository=notificationrepository;
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
           return await _customerRepository.GetCustomers();
            //return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomersById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public IActionResult PutCustomer(int id, Customer customer)
        [HttpPut]
        public IActionResult PutCustomer(Customer customer)
        {
            /*if (id != customer.Id)
            {
                return BadRequest();
            }*/


            try
            {
                _customerRepository.PutCustomer(customer);
            }
           
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }

            return Ok(customer); //NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, bool email)
        {
            var customer = await _customerRepository.GetCustomersById(id);
            customer.EmailNotificationEnable=email;

            try
            {
                _customerRepository.PutCustomer(customer);
            }
           
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }

            return Ok(customer); //NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Customer> PostCustomer(Customer customer)
        {
            //_context.Customers.Add(customer);
            //await _context.SaveChangesAsync();
             _customerRepository.CreateCustomer(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomer(int id)
        {
            //var customer = await _context.Customers.FindAsync(id);
            var customer = _customerRepository.DeleteCustomers(id);
            if (customer == null)
            {
                return NotFound();
            }

            //_context.Customers.Remove(customer);
            //await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
