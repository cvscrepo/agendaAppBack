using CalendarAppBack.BLL;
using CalendarAppBack.BLL.Contrato;
using CalendarAppBack.DAL;
using CalendarAppBack.DAL.Repositorios;
using CalendarAppBack.DAL.Repositorios.Contrato;
using CalendarAppBack.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.IOC
{
    public static class Dependecia
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuraction)
        {
            // Aquí se inyectarán las dependencias
            service.AddDbContext<CalendarContext>(options =>
            {
                options.UseSqlServer(configuraction.GetConnectionString("cadenaSql"));
            });
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddAutoMapper(typeof(AutoMapperProfile));
            service.AddScoped<IServicesService, ServicesService>();
            service.AddScoped<IAppointmentService, AppointmentService>();
        }
    }
}
