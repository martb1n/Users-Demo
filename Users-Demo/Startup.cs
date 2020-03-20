using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Users_Demo.Config;
using Users_Demo.DAL;

namespace Users_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Users-Demo.Handler");
            services.AddMediatR(assembly);
            services.AddValidator();
            services.AddServices();
            services.AddControllers();
            services.AddDbContext<UsersDemoContext>(opt =>
              opt.UseInMemoryDatabase("UsersList"));
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("5.0", new OpenApiInfo { Title = "Users Demo API", Version = "5.0" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/5.0/swagger.json", "Users Demo API");
            });
        }
    }
}
