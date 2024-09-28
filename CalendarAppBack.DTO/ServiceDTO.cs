using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.DTO
{
    public class ServiceDTO
    {
        public int IdService { get; set; }

        public string NameService { get; set; } = null!;

        public string DescriptionServicios { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AppointmentDTO> Appointments { get; } = new List<AppointmentDTO>();
    }
}
