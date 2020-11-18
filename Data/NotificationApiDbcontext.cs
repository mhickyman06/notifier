using Microsoft.EntityFrameworkCore;
using NotificationApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Data
{
    public class NotificationApiDbcontext : DbContext
    {
        public NotificationApiDbcontext(DbContextOptions<NotificationApiDbcontext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
