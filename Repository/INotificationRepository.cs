using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotificationApi.Model;
using NotificationApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace NotificationApi.Repository
{
    public interface INotificationRepository
    {
        void Add(Customer item);
        void Remove(Customer item);
        IEnumerable<Customer> ListAll();
        // Task<ActionResult<IEnumerable<Customer>>> GetCustomers();
        // Customer GetById(int id);
        void Save();
    }
}


