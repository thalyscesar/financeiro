using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceiroNucleo.Negocio;
using FinanceiroNucleo.Repositorios;
using FinanceiroNucleo.Repositorios.Data;
using FinanceiroNucleo.Repositorios.Interfaces;
using FinanceiroNucleo.Servicos;
using FinanceiroNucleo.Servicos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Delivery.Api
{
    public class Startup
    {
        private readonly string _cors = "delivery";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<FinanceiroContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IContaAPagarService,ContaAPagarService>();
            services.AddScoped<IRepository<ContaAPagar>, ContaAPagarRepository>();


            services.AddCors(c => c.AddPolicy(_cors, b =>
            {
                b.WithOrigins("http://localhost:4200");
                b.WithMethods("GET", "POST", "PUT", "DELETE");
                b.AllowAnyHeader();
                b.AllowCredentials();
                b.AllowAnyMethod();

            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(_cors);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
