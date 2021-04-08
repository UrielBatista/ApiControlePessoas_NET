using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PessoasDataApi.Repository;
using PessoasDataApi.Services;
using PessoasDataApi.Services.Support;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace PessoasDataApi
{
    public class Startup
    {
        //Docker configurations for SQLServer
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

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddControllers();

            // Autenticação JWT 
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });

            // Buscando credenciais para acesso a banco de dados
            services
                .AddHealthChecks()
                .AddSqlServer($"Server={DATABASE_HOST};Database={DATABASE_NAME};User Id={DATABASE_USER};Password={DATABASE_PASS}", tags: new[] { "services" });

            services.AddScoped<IPessoasRepository, PessoasRepository>();
            services.AddScoped<IPessoasService, PessoasService>();
            services.AddScoped<IMessageService, LogData>();


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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
