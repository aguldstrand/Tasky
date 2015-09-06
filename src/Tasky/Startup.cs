using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Tasky.Services;
using Tasky.Models;

namespace Tasky
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDataStore<Project>, CommonDataStore<Project>>();
            services.AddTransient<IDataStore<Project, Sprint>, CommonDataStore<Project, Sprint>>();
            services.AddTransient<IDataStore<Project, Sprint, Issue>, CommonDataStore<Project, Sprint, Issue>>();
            services.AddTransient<IDataStore<Project, Sprint, Issue, Comment>, CommonDataStore<Project, Sprint, Issue, Comment>>();
            services.AddTransient<IDataStore<Project, Sprint, Issue, Attachment>, CommonDataStore<Project, Sprint, Issue, Attachment>>();

            services.AddTransient<IDataStore<User>, CommonDataStore<User>>();
            services.AddTransient<IDataStore<UserGroup>, CommonDataStore<UserGroup>>();

            services.AddMvc();
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();

            services.AddSwagger();

        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
