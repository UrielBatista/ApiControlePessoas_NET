using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PessoasDataApi.Repository;
using PessoasDataApi.Services;
using PessoasDataApi.Services.Support;
using System;

namespace PessoasDataApi
{
    public class Startup
    {
        private static readonly string DATABASE_HOST = Environment.GetEnvironmentVariable("DATABASE_HOST");
        private static readonly string DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");
        private static readonly string DATABASE_USER = Environment.GetEnvironmentVariable("DATABASE_USER");
        private static readonly string DATABASE_PASS = Environment.GetEnvironmentVariable("DATABASE_PASS");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Controle Pessoas",
                    Version = "v1"
                });
            });

            services.AddControllers();

            services
                .AddHealthChecks()
                .AddSqlServer($"Server={DATABASE_HOST};Database={DATABASE_NAME};User Id={DATABASE_USER};Password={DATABASE_PASS}", tags: new[] { "services" });

            services.AddScoped<IPessoasRepository, PessoasRepository>();
            services.AddScoped<IPessoasService, PessoasService>();
           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Controle Pessoas V1");
            });

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
