using AutoMapper;
using CalendarAppBack.DTO;
using CalendarAppBack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Appointment
            CreateMap<AppointmentDTO, Appointment>()
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.Parse(src.StartDate)))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateTime.Parse(src.EndDate))).ReverseMap();
            #endregion

            #region Service
            CreateMap<Service, ServiceDTO>().ReverseMap() ;
            #endregion

            #region User
            CreateMap<UserCalendar, UserCalendar>().ReverseMap();
            #endregion

            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion
        }
    }
}
