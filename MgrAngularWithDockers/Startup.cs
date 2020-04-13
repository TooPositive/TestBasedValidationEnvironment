using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MgrAngularWithDockers.Core.Generics;
using AutoMapper;
using MgrAngularWithDockers.Core.Extensions;
using Microsoft.AspNet.OData.Extensions;
using MgrAngularWithDockers.Core.Models.db;
using System;

namespace MgrAngularWithDockers
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
            // In production, the Angular files will be served from this directory

            AutoMapperConfiguration(services);

            InitDb(services);

            services.AddControllers().AddNewtonsoftJson();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();



            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://webangular:4200");
                }
            });

            
        }


        private void InitDb(IServiceCollection services)
        {

            var server = Configuration["DBServer"] ?? "db-server";
            var port = Configuration["DBPort"] ?? "1400";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Mgr5432!";
            var database = Configuration["Database"] ?? "MgrAngularWithDockers";
            var inDocker = bool.Parse(Configuration["InDocker"] ?? "false");
            Console.WriteLine($"IN docker --- > ${inDocker}");
            var connectionString = inDocker ? $"Server={server},{port};Database={database};User={user};Password={password}" : "DefaultConnection";// DOCKER & LOCAL
            Console.WriteLine($"connection string {connectionString}");

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString) 
                    .UseLazyLoadingProxies());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        private void AutoMapperConfiguration(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
