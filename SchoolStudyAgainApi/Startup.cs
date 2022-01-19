using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SchoolBusinessLogic.BusinessLogic.DocumentLogics;
using SchoolBusinessLogic.BusinessLogic.StudentLogics;
using SchoolBusinessLogic.BusinessLogic.TeacherLogics;
using SchoolBusinessLogic.Interfaces.Diagram;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolDatabaseImplement;
using SchoolDatabaseImplement.Implements.Diagram;
using SchoolDatabaseImplement.Implements.Student;
using SchoolDatabaseImplement.Implements.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStudyAgainApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolStudyAgainApi", Version = "v1" });
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SchoolDbContext>(options =>
                options.UseNpgsql(connection));


            services.AddTransient<ITeacherStorage, TeacherStorage>();
            services.AddTransient<IMaterialStorage, MaterialStorage>();
            services.AddTransient<IElectiveStorage, ElectiveStorage>();
            services.AddTransient<IMedalStorage, MedalStorage>();
            services.AddTransient<IStudentStorage, StudentStorage>();
            services.AddTransient<IActivityStorage, ActivityStorage>();
            services.AddTransient<IInterestStorage, InterestStorage>();
            services.AddTransient<IDiagramDataStorage, DiagramStorage>();
            services.AddTransient<MaterialLogic>();
            services.AddTransient<TeacherLogic>();
            services.AddTransient<ReportLogic>();
            services.AddTransient<ElectiveLogic>();
            services.AddTransient<MedalLogic>();
            services.AddTransient<ActivityLogic>();
            services.AddTransient<InterestLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolStudyAgainApi v1"));

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
