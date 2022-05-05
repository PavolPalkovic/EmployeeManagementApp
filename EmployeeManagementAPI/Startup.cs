using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeManagementAPI.Context;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {   
            // Enables sending of requests
            services.AddCors(c => 
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddMvc(options => options.EnableEndpointRouting = false);

            // Enables Json Patch 
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();

            var connectionString = _configuration["connectionStrings:employeeInfoDBConnectionString"];
            // "Server=172.17.0.2,1433;integrated security=false;User Id=SA;Password=h^3K9\S6;Database=EmployeeInfoDB";
            // Registers EmployeeDbContext
            services.AddDbContext<EmployeeDbContext>(options =>
                // Connects to DB
                options.UseSqlServer(connectionString));

            // Registration of repository service
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IEmployeeHistoryRepository, EmployeeHistoryRepository>();
            // Registration of AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ensures that all requests to the web application are routable to MVC framework,
            // meaning you can use controller, views and 
            app.UseMvc();

            // app.UseRouting();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });
        }
    }
}
