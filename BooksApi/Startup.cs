using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BooksApi.Models;

namespace BooksApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.Configure<BookstoreDatabasesettings>(Configuration.GetSection(nameof(BookstoreDatabaseSettings)));
            //The configuration instance to which appsettings.json file's BookstoreDatabaseSettings section binds is registered in DI container
            //DI container is a framework for implementing automatic Dependency injection
            //The 'container' creates an object of the specified class and also injects all the dependency objects through a constructor,
            //a property or a method at run time and disposes it at the appropriate time so that we dont have to create/manage objects manually
            //For example BookstoreDatabaseSettings' object's ConnectionString property is populated with the BookstoreDatabaseSettings:ConnectionString
            //property in appsettings.json
            services.AddSingleton<IBookstoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>.Value());
            //The IBookstoreDatabaseSettings interface is registered in DI with a singleton service.
            //When injected,the interface resolves to a BookstoreDatabaseSettings object
            //By 'registering' in DI container - the container must know which depedency to instantiate,this process is called registration
            //While resolving depedency,the container will create the objects automatically(this process is called resolve)
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
