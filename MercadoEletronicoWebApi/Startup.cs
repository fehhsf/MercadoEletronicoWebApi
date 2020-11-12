using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Repository;
using Modelo.Service;
using Modelo.Service.Interfaces;
using Modelo.Service.Services;
using System.Text.Json;
using Newtonsoft.Json.Serialization;

namespace MercadoEletronicoWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200",
                                                          "https://localhost:4200")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });
            services.AddControllers();



            services.AddControllers().AddNewtonsoftJson();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });



            #region Services Dependency Injection
            //Services            
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IItemPedidoService, ItemPedidoService>();


            #endregion

            #region Repository Dependency Injection
            //Repository            
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

            #endregion

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(MyAllowSpecificOrigins);

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

            app.UseAuthentication();
        }
    }
}
