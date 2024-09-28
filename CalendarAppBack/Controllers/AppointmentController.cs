using CalendarAppBack.BLL.Contrato;
using CalendarAppBack.DTO;
using CalendarAppBack.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CalendarAppBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            ResponseController response = new ResponseController();
            try
            {
                List<AppointmentDTO> appointmentDTOs = await _appointmentService.GetAllAppointments();
                response.Success = true;
                response.Message = "Citas obtenidas correctamente";
                response.Value = appointmentDTOs;
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet("{idAppointment}")]
        public async Task<IActionResult> GetAppointment(int idAppointment)
        {
            ResponseController response = new ResponseController();
            try
            {
                AppointmentDTO appointmentDTO = await _appointmentService.GetAppointment(idAppointment);
                response.Success = true;
                response.Message = "Cita obtenida correctamente";
                response.Value = appointmentDTO;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDTO appointment)
        {
            ResponseController response = new ResponseController();
            try
            {
                AppointmentDTO appointmentDTO = await _appointmentService.CreateAppointment(appointment);
                response.Success = true;
                response.Message = "Cita creada correctamente";
                response.Value = appointmentDTO;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditAppointment([FromBody] AppointmentDTO appointment)
        {
            ResponseController response = new ResponseController();
            try
            {
                AppointmentDTO appointmentDTO = await _appointmentService.EditAppointment(appointment);
                response.Success = true;
                response.Message = "Cita editada correctamente";
                response.Value = appointmentDTO;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpDelete("{idAppointment}")]
        public async Task<IActionResult> DeleteAppointment(int idAppointment)
        {
            ResponseController response = new ResponseController();
            try
            {
                AppointmentDTO appointmentDTO = await _appointmentService.DeleteAppointment(idAppointment);
                response.Success = true;
                response.Message = "Cita eliminada correctamente";
                response.Value = appointmentDTO;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

    }
}
