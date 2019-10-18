using MyProject.Domain.Entities;
using MyProject.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyProject.Application.Customers.Queries.GetCustomer;
using Swashbuckle.AspNetCore.Swagger;
using VueCliMiddleware;

namespace MyProject.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "../CustomerApp/dist";
            });
            // Add DbContext using SQL Server Provider
            services.AddDbContext<MyProjectDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyProjectDb")));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info()
            {
                Title = "Centre veterinari triomf api",
                Version = "v1"
            }));
            services.AddMediatR(typeof(GetCustomerQuery).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CVT API v1");
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseMvc(routes =>  routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}"));

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });
            
        }
    }
}
