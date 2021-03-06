using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;

namespace SchoolStudyAgain
{
    public class Program
    {
        public static TeacherViewModel Teacher { get; set; }

        public static StudentViewModel Student { get; set; }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
