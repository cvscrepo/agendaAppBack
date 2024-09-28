using CalendarAppBack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.BLL.Contrato
{
    public interface IServicesService
    {
        public Task<List<ServiceDTO>> GetAllServices();
        public Task<ServiceDTO> CreateService(ServiceDTO service);
        public Task<ServiceDTO> DeleteService(int idService);
    }
}
