using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.DTO
{
    public class UserCalendarDTO
    {
        public int IdUser { get; set; }

        public string FullName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string PasswordUser { get; set; } = null!;

        public bool? StateUser { get; set; }

        public string? UrlPhoto { get; set; }

        public int? Rol { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AppointmentDTO> Appointments { get; } = new List<AppointmentDTO>();

        public virtual RolDTO? RolNavigation { get; set; }
    }
}
