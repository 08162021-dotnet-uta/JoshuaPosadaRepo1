using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStoreBusinessLayer;
using DemoStoreBusinessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Project1.StoreApplication.Storage;
using Project1.StoreApplication.Storage.Models;

namespace StoreDemoUi
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

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreDemoUi", Version = "v1" });
			});

			services.AddDbContext<Demo_08162021batchContext>(options =>
			{
				//if db options is already configured, done do anything..
				// otherwise use the Connection string I have in secrets.json
				if (options.IsConfigured)
				{
					options.UseSqlServer(Configuration.GetConnectionString("DevDb"));
				}
			});

			//registering classes with the DI system.
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IModelMapper, ModelMapper>();
			services.AddMvc(c => c.Conventions.Add(new ApiExplorerIgnores()));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreDemoUi v1"));
			}

			// To enable default text-only handlers for common error status codes
			app.UseStatusCodePages();

			app.UseHttpsRedirection();

			// use this to redirect to the index HTML for any random path
			app.UseRewriter(new RewriteOptions()
				.AddRedirect("^$", "index.html"));

			// use the .js static files
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}


//// Unused usings removed
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using TodoApi.Models;

//namespace TodoApi
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllers();

//            services.AddDbContext<TodoContext>(opt =>
//                                               opt.UseInMemoryDatabase("TodoList"));
//            //services.AddSwaggerGen(c =>
//            //{
//            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
//            //});
//        }
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseDefaultFiles();
//            app.UseStaticFiles();

//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }

//        /*     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//             {
//                 if (env.IsDevelopment())
//                 {
//                     app.UseDeveloperExceptionPage();
//                     //app.UseSwagger();
//                     //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
//                 }

//                 app.UseHttpsRedirection();
//                 app.UseRouting();

//                 app.UseAuthorization();

//                 app.UseEndpoints(endpoints =>
//                 {
//                     endpoints.MapControllers();
//                 });
//             }*/
//    }
//}