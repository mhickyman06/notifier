using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationApi.Data;
using NotificationApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NotificationApi.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationApiDbcontext _dbContext;

        public NotificationRepository(NotificationApiDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Customer item) => _dbContext.Customers.Add(item);

        public void Remove(Customer item) => _dbContext.Customers.Remove(item);

        // public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        // {
        //         return await _dbContext.Customers.ToListAsync();
        // }

         public IEnumerable<Customer> ListAll() => _dbContext.Customers.ToList();

        public Customer GetById(int id) => _dbContext.Customers.Find(id);

        public void Save() => _dbContext.SaveChanges();
    }
}