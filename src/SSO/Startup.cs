using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSO.Infra.CrossCutting.IoC;
using SSO.Infra.Data.MongoDatabase.Configurations;

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
