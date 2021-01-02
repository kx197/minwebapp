using Funq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinWebApp.ServiceInterface;
using ServiceStack;
using ServiceStack.Admin;
using ServiceStack.Api.OpenApi;
using ServiceStack.NativeTypes.TypeScript;
using System.Collections.Generic;
using System.Linq;

namespace MinWebApp
{
    public class Startup : ModularStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public new void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseServiceStack(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("MinWebApp", typeof(CompanyServices).Assembly) { }

        // Configure your AppHost with the necessary configuration and dependencies your App needs
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false),
                TreatNonNullableRefTypesAsRequired = true    // Note: not applicable to Value types
            });

            // Register plugins
            Plugins.Add(new AdminFeature());
            Plugins.Add(new PostmanFeature());
            Plugins.Add(new OpenApiFeature());

            ConfigureTypeScriptGenerator(container);
        }

        // Customise TypeScript generation for client
        private void ConfigureTypeScriptGenerator(Container container)
        {
            // Disable TypeScript compiler errors
            TypeScriptGenerator.InsertTsNoCheck = true;

            TypeScriptGenerator.UseNullableProperties = true;

            TypeScriptGenerator.IsPropertyOptional = (gen, type, prop) =>
            {
                return !(prop.IsRequired ?? false);
            };               
        }
    }
}
