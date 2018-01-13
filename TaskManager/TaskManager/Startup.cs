using System;
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
using Microsoft.AspNetCore.Identity;
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

            string connection = "Server = HP\\SQLEXPRESS;Database=TaskManager;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddTransient<IRepository<DAL.Entities.Task>, TaskRepository>(provider => new TaskRepository(connection));
            services.AddTransient<IRepository<DAL.Entities.User>, UserRepository>(provider => new UserRepository(connection));

            services.AddTransient<TaskServices>();
            services.AddTransient<UserService>();

            //services.AddSingleton(provider => new TaskServices(taskRepository));
            //services.AddSingleton(provider => new UserService(userRepository));


            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

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
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Task}/{action=Index}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices  // Создаем Service Scope для инициализации всех сервисов
                   .GetRequiredService<IServiceScopeFactory>()
                   .CreateScope())
            {  // Получаем экземпляр ApplcationDbContext из ServiceProvider-а
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
                // Применяем непримененные миграции
                context.Database.Migrate();
                // Получаем RoleManager
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                // Проверяем, есть ли роль Admins. Если нет - добавляем.
                var admins = roleManager.FindByNameAsync("Admins").Result;
                if (admins == null)
                {
                    var roleResult = roleManager.CreateAsync(new IdentityRole("Admins")).Result;
                }
                var users = roleManager.FindByNameAsync("Users").Result;
                if (users == null)
                {
                    var roleResult = roleManager.CreateAsync(new IdentityRole("Users")).Result;
                }
                // Получаем UserManager
                var userManager =
               serviceScope.ServiceProvider.GetService<UserManager<User>>();
                // Проверяем, есть ли пользователь
                var admin = userManager.FindByNameAsync("admin@tusur.com").Result;
                if (admin == null)
                {                  // Если нет - создаем
                    var userResult = userManager.CreateAsync(new User
                    {
                        UserName = "admin@tusur.com",
                        Email = "admin@tusur.com"
                    }, "AdminPass123!").Result;
                    admin = userManager.FindByNameAsync("admin@csdevents.com").Result;
                    // И добавляем ему роль Admins
                    userManager.AddToRoleAsync(admin, "Admins").Wait();
                }
            }
        }
    }
}
