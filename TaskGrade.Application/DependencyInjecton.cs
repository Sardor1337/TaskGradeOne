using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Abstractions;
using TaskGrade.Application.Services;

namespace TaskGrade.Application
{
    public static class DependencyInjecton
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IScienseService, ScienseService>();
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
