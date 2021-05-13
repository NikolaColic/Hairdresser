using Hair.Data.Context;
using Hair.Data.Entities;
using Hair.Service.Interface;
using Hair.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hair.Api
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
            services.AddDbContext<HairdresserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGeneric<FavouriteHairdresser>, FavouriteHairdresserService>();
            services.AddScoped<IGeneric<HairdresserImage>, HairdresserImageService>();
            services.AddScoped<IGeneric<Hairdresser>, HairdresserService>();
            services.AddScoped<IGeneric<Municipality>, MunicipalityService>();
            services.AddScoped<IGeneric<Reservation>, ReservationService>();
            services.AddScoped<IGeneric<SocialNetwork>, SocialNetworkService>();
            services.AddScoped<IGeneric<User>, UserService>();
            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                
            services.AddApiVersioning((setupAction) =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;

            });
            services.AddSwaggerGen((setupAction) =>
            {
                setupAction.SwaggerDoc("HairdresserApi", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Hairdresser REST API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Nikola Čolić",
                        Email = "nikolacolic997@gmail.com",
                    },
                    Description = "This is REST API documentation for online reservation in hairdresser",
                    Version = "1",
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "MIT Licence",
                        Url = new Uri("https://opensource.org/licences/MIT")
                    }

                }) ;
                var xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlDocFullPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
                setupAction.IncludeXmlComments(xmlDocFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/HairdresserApi/swagger.json", "Hairdresser API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
