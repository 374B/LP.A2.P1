using System.IO;
using LP.University.API.Filters;
using LP.University.Infrastructure.Data.InMemory;
using LP.University.Infrastructure.Registrar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace LP.University.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //options.Filters.AddService<ExceptionFilter>();
                options.Filters.Add(new ExceptionFilter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "LP.University.API",
                    Version = "v1"
                });

                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "LP.University.API.xml"));
            });

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LP.University.API V1");
                });

                SetFakeData();
            }

            app.UseMvc();

        }

        private void RegisterServices(IServiceCollection services)
        {
            //Register services outside this project
            var registrar = new Registrar();
            registrar.RegisterServices(services);

            //Register local services
            //...

        }

        private void SetFakeData()
        {
            new FakeData().Generate(20, 10);
        }
    }
}
