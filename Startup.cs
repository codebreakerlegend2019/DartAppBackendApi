using AutoMapper;
using DartAppSingapore.DataContexts;
using DartAppSingapore.Helpers;
using DartAppSingapore.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
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
                        Title = "Dart App Backend ni Eunice REST API",
                        Version = "v1",
                        Contact = new OpenApiContact()
                        {
                            Name = "Joshua Siuagan",
                            Url = new Uri("https://github.com/codebreakerlegend2019"),
                            Email = "joshuasiuagan0406@gmail.com",
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });
            services.AddControllersWithViews();
            services.ConfigureCors();
            services.AddMvc()
            .ConfigureApiBehaviorOptions(options=> 
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errorInModelState = actionContext.ModelState
                       .Where(x => x.Value.Errors.Count > 0)
                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage))
                       .ToArray();

                    var errorResponse = new List<Error>();

                    foreach (var errors in errorInModelState)
                        foreach (var subError in errors.Value)
                            errorResponse.Add(new Error(subError));
                    return new BadRequestObjectResult(errorResponse);
                };
            })
            .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dartappcms/build";
            });
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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dart App ni Eunice REST API");
            });
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSwagger();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp/dartappcms";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
