using DatabaseManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace AlertToCare
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

            services.AddDbContext<DatabaseContext>();

            services.AddSingleton<RepositoryManager.FacilityManager.IFacilityDataHandler,
                RepositoryManager.FacilityManager.FacilityDataHandler>();
            services.AddSingleton<RepositoryManager.PatientManager.IPatientDataHandler,
               RepositoryManager.PatientManager.PatientDataHandler>();
            services.AddSingleton<RepositoryManager.VitalManager.IVitalDataHandler,
               RepositoryManager.VitalManager.VitalDataHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
