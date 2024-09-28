using CalendarAppBack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.BLL.Contrato
{
    public interface IAppointmentService
    {
        public Task<List<AppointmentDTO>> GetAllAppointments();
        public Task<AppointmentDTO> GetAppointment(int idAppointment);
        public Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointment);  
        public Task<AppointmentDTO> EditAppointment(AppointmentDTO appointment);
        public Task<AppointmentDTO> DeleteAppointment(int idAppointment);
    }
}
