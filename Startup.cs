using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NotificationApi.Data;
using NotificationApi.Repository;
using static NotificationApi.Repository.ICustomerRepository;

namespace NotificationApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>(); 
            services.AddTransient<INotificationRepository, NotificationRepository>();
                     
            services.AddDbContextPool<NotificationApiDbcontext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("NotificationApi", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "A web api that determines if a bank customer wants either SMS Noification, InApp NOtification,or EmailNotification",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Madu  Michael",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },

                });
            });
                services.AddControllers();
           
           }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/NotificationApi/swagger.json", "NotificationApi");
                //x.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
