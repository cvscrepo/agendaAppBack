using AutoMapper;
using Azure.Core.Pipeline;
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
    public class ServicesService : IServicesService
    {
        private readonly IGenericRepository<Service> _serviceRepository;
        private readonly IMapper _mapper;

        public ServicesService(IGenericRepository<Service> serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<List<ServiceDTO>> GetAllServices()
        {
            try
            {
               IQueryable<Service> services = await _serviceRepository.Consultar();
                List<ServiceDTO> servicesDTO = _mapper.Map<List<ServiceDTO>>(services);
                return servicesDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ServiceDTO> CreateService(ServiceDTO service)
        {
            try
            {
                Service serviceFound = await _serviceRepository.Obtener(x => x.IdService == service.IdService);
                if (serviceFound != null)
                {
                    throw new Exception("El servicio ya existe");
                }
                Service services = _mapper.Map<Service>(service);
                Service serviceCreated = await _serviceRepository.Crear(services);
                return _mapper.Map<ServiceDTO>(serviceCreated);

            }
            catch
            {
                throw;

            }
        }

        public async Task<ServiceDTO> DeleteService(int idService)
        {
            try
            {
                Service serviceFound = await _serviceRepository.Obtener(x => x.IdService == idService);
                if (serviceFound == null)
                {
                    throw new Exception("El servicio no existe");
                }
                bool serviceDeleted = await _serviceRepository.Eliminar(serviceFound);
                if(serviceDeleted)
                {
                    return _mapper.Map<ServiceDTO>(serviceFound);
                }
                else
                {
                    throw new Exception("No se pudo eliminar el servicio");
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
