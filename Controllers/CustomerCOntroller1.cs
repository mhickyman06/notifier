using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationApi.Model;
using NotificationApi.Repository;
using NotificationApi.Data;


namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer1Controller : ControllerBase
    {
        private readonly NotificationApiDbcontext _context;
        private readonly INotificationRepository _notificationRepository;
        public Customer1Controller(NotificationApiDbcontext context,
            INotificationRepository notificationrepository)
        {
            _notificationRepository=notificationrepository;
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _notificationRepository.ListAll();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}