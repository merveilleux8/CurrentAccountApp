using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrentAccount.Account.Service;
using CurrentAccount.Account.Service.Impl;
using CurrentAccount.Account.Service.Models;
using CurrentAccount.Account.ServiceHost.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CurrentAccount.Account.ServiceHost
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

            services.AddMemoryCache();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache memoryCache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrentAccount Account API");
            });
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //customer setup
            var entryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);
            var customers = new List<Customer>()
            {
                new Customer() {CustomerId = 1, Name="Merve1", Surname="Pehlivan1" },
                new Customer() {CustomerId = 2, Name="Merve2", Surname="Pehlivan2" },
                new Customer() {CustomerId = 3, Name="Merve3", Surname="Pehlivan3" },
                new Customer() {CustomerId = 4, Name="Merve4", Surname="Pehlivan4" },
                new Customer() {CustomerId = 5, Name="Merve5", Surname="Pehlivan5" },
                new Customer() {CustomerId = 6, Name="Merve6", Surname="Pehlivan6" },
                new Customer() {CustomerId = 7, Name="Merve7", Surname="Pehlivan7" },
                new Customer() {CustomerId = 8, Name="Merve8", Surname="Pehlivan8" }

            };
            memoryCache.Set("customers", customers, entryOptions);
            memoryCache.Set("accounts", new List<UserAccount>(), entryOptions);

        }
    }
}
