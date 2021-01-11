using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using SSO.Infra.CrossCutting.IoC;
using SSO.Infra.Data.MongoDatabase.Configurations;
using System;
using System.Threading.Tasks;

namespace SSO
{
    public class Startup
    {
        private const string AppSettingsFile = "appsettings";
        private const string JsonTermination = "json";
        IConfiguration Configuration;

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"{AppSettingsFile}.{JsonTermination}", false, true)
                .AddJsonFile($"{AppSettingsFile}.{env.EnvironmentName}.{JsonTermination}", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            DatabaseConfiguration.Configure();
            AppSettings.Configure(Configuration);
            IoCConfiguration.ConfigureServiceLocator();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddMvcOptions(x => x.EnableEndpointRouting = false);

            IdentityModelEventSource.ShowPII = true;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("aXQgaXMgYSBzdHJpbmcgd2l0aCAxNiBjaGFycw==")),
                        //ValidIssuer = Configuration["Jwt:Issuer"],
                        //ValidAudience = Configuration["Jwt:Audience"]
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {

                            return Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {

                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {

                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            IoCConfiguration.AddServiceLocatorTo(builder);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
