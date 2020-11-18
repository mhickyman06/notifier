using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationApi.Data;
using NotificationApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Repository
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Task<ActionResult<IEnumerable<Customer>>> GetCustomers();
        Task<Customer> GetCustomersById(int id);
        void PutCustomer(int id,Customer customer);
        void PutCustomer(Customer customer);
        Customer DeleteCustomers(int id);
    }
        public class CustomerRepository : ICustomerRepository
        {
            private readonly NotificationApiDbcontext _context;
            public CustomerRepository(NotificationApiDbcontext context)
            {
                _context = context;
            }
            public async void CreateCustomer(Customer customer)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }

            public Customer DeleteCustomers(int id)
            {
                var customer =  _context.Customers.Find(id);
                 _context.Customers.Remove(customer);
                    _context.SaveChanges();
                return customer;

            }

            public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
            {
                return await _context.Customers.ToListAsync();
            }

            public async Task<Customer> GetCustomersById(int id)
            {
                var customer = await _context.Customers.FindAsync(id);
                return customer;
            }

            public  void PutCustomer(int id, Customer customer)
            {
                _context.Entry(customer).State = EntityState.Modified;
                   _context.SaveChanges();
            
            }

            public  void PutCustomer(Customer customer)
            {
                _context.Entry(customer).State = EntityState.Modified;
                   _context.SaveChanges();
            
            }
        }
    }

