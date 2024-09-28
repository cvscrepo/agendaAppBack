using CalendarAppBack.BLL.Contrato;
using CalendarAppBack.DTO;
using CalendarAppBack.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CalendarAppBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            ResponseController response = new ResponseController();
            try
            {
                List<ServiceDTO> serviceDTOs = await _servicesService.GetAllServices();
                response.Success = true;
                response.Message = "Servicios obtenidos correctamente";
                response.Value = serviceDTOs;
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
        public async Task<IActionResult> CreateService(ServiceDTO serviceDTO)
        {
            ResponseController response = new ResponseController();
            try
            {
                ServiceDTO service = await _servicesService.CreateService(serviceDTO);
                response.Success = true;
                response.Message = "Servicio creado correctamente";
                response.Value = service;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpDelete("{idService}")]
        public async Task<IActionResult> DeleteService(int idService)
        {
            ResponseController response = new ResponseController();
            try
            {
                ServiceDTO service = await _servicesService.DeleteService(idService);
                response.Success = true;
                response.Message = "Servicio eliminado correctamente";
                response.Value = service;
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
