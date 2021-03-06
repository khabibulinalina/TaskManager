﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManager.Models;
using TaskManager.DAL.Interfaces;
using TaskManager.BLL.Services;
using TaskManager.DAL.Repositories;

namespace TaskManager
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
            //string connection = Configuration.GetConnectionString("DefaultConnection");
           // services.AddDbContext<TaskContext>(options => options.UseSqlServer(connection));
           
            string connection = "Server = HP\\SQLEXPRESS;Database=TaskManager;Trusted_Connection=True;MultipleActiveResultSets=true";
            var taskRepository = new TaskRepository(connection);
            var employeeRepository = new EmployeeRepository(connection);

            services.AddTransient<IRepository<DAL.Entities.Task>, TaskRepository>(provider => taskRepository);
            services.AddTransient<IRepository<DAL.Entities.Employee>, EmployeeRepository>(provider => employeeRepository);

            services.AddSingleton(provider => new TaskServices(taskRepository));
            services.AddSingleton(provider => new EmployeeService(employeeRepository));

            services.AddMvc();

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Task}/{action=Index}/{id?}");
            });
        }
    }
}
