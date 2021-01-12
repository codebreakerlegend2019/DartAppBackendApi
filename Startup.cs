using AutoMapper;
using DartAppSingapore.DataContexts;
using DartAppSingapore.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DartAppSingapore
{
    public class Startup
    {
#if (!DEBUG)
        private readonly string _sqlDataBaseConnectringString = "ProductionDartApp";
#else

        private readonly string _sqlDataBaseConnectringString = "DevelopmentDartApp";
#endif
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AutoRegisterByNameSpace("Persistence");
            services.AutoRegisterByInterfaceName("ICrud");
            services.AddDbContext<DartAppContext>(options => options.UseLazyLoadingProxies()
       .UseSqlServer(
      Configuration.GetConnectionString(_sqlDataBaseConnectringString),
      sqlServerOptions => sqlServerOptions.CommandTimeout(999)
      ));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Dart App ni Eunice REST API",
                        Version = "v1"
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });
            services.AddControllersWithViews();
            services.ConfigureCors();
        }
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dart App ni Eunice REST API");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
