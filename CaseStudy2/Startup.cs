using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace WebApiDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        //Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Once instance of type PatientMemoryDBRepository created - Any number of Resolve request
            services.AddSingleton<CaseStudy2.Service.IOccupancyService, CaseStudy2.ServiceImpl.OccupancyServiceImpl> ();
            services.AddSingleton<CaseStudy2.Service.IIcuConfigurationService, CaseStudy2.ServiceImpl.ConfigurationImpl>();
            services.AddSingleton<CaseStudy2.Service.IMonitorService, CaseStudy2.ServiceImpl.MonitorServiceImpl>();
            //One instace/ Request
            //services.AddTransient<Repository.IPatientDataRepository, Repository.PatientMemoryDBRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
