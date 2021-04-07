using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolDatabaseImplement.Implements.Student;
using SchoolDatabaseImplement.Implements.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRestApi
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
            services.AddTransient<ITeacherStorage, TeacherStorage>();
            services.AddTransient<IMaterialStorage, MaterialStorage>();
            services.AddTransient<IElectiveStorage, ElectiveStorage>();
            services.AddTransient<IMedalStorage, MedalStorage>();
            services.AddTransient<IStudentStorage, StudentStorage>();
            services.AddTransient<IActivityStorage, ActivityStorage>();
            services.AddTransient<IInterestStorage, InterestStorage>();
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
