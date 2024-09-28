using AutoMapper;
using CalendarAppBack.BLL.Contrato;
using CalendarAppBack.DAL.Repositorios.Contrato;
using CalendarAppBack.DTO;
using CalendarAppBack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.BLL
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IGenericRepository<Appointment> appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDTO>> GetAllAppointments()
        {
            try
            {
                IQueryable<Appointment> appointments = await _appointmentRepository.Consultar();
                List<AppointmentDTO> appointmentsDTO = _mapper.Map<List<AppointmentDTO>>(appointments);
                return appointmentsDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AppointmentDTO> GetAppointment(int idAppointment)
        {
            try
            {
                Appointment appointment = await _appointmentRepository.Obtener(x => x.IdAppointment == idAppointment) ?? throw new Exception("Cita no encontrada");
                AppointmentDTO appointmentDTO = _mapper.Map<AppointmentDTO>(appointment);
                return appointmentDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointment)
        {
            try
            {
                Appointment appointmentCreated = await _appointmentRepository.Crear(_mapper.Map<Appointment>(appointment));
                return _mapper.Map<AppointmentDTO>(appointmentCreated);
            }
            catch
            {
                throw;
            }
        }
        public async Task<AppointmentDTO> EditAppointment(AppointmentDTO appointment)
        {
            try
            {
                Appointment appointmentFound = await _appointmentRepository.Obtener(x => x.IdAppointment == appointment.IdAppointment) ?? throw new Exception("Cita no encontrada");
                bool appointmentEdited = await _appointmentRepository.Editar(_mapper.Map<Appointment>(appointment));
                return appointment;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AppointmentDTO> DeleteAppointment(int idAppointment)
        {
            try
            {
                Appointment appointmentFound = await _appointmentRepository.Obtener(x => x.IdAppointment == idAppointment) ?? throw new Exception("Cita no encontrada");
                bool appointmentDeleted = await _appointmentRepository.Eliminar(appointmentFound);
                if (appointmentDeleted)
                {
                    return _mapper.Map<AppointmentDTO>(appointmentFound);
                }
                else
                {
                    throw new Exception("No se pudo eliminar la cita");
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
