using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
using System.Text;
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
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolStudyAgainApi", Version = "v1" });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SchoolDbContext>(options =>
                options.UseNpgsql(connection));


            #region auth

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            #endregion

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
