using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ModelsAPI.Client.Repositories;
using ModelsAPI.Client.Services;
using GR = ModelsAPI.Global.Repositories;
using GS = ModelsAPI.Global.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tools.Connections.Database;
using MoneyManager.API.Infrastructure.Security;

namespace MoneyManager.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoneyManager.API", Version = "v1" });
            });
            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, Configuration.GetConnectionString("MoneyManagerDB")));
            services.AddSingleton<GR.IAuthRepository, GS.AuthService>();
            services.AddSingleton<GR.ICategoryRepository, GS.CategoryService>();
            services.AddSingleton<ICategoryRepository, CategoryService>();
            services.AddSingleton<IAuthRepository, AuthService>();
            services.AddSingleton<ITokenRepository, TokenService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoneyManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
