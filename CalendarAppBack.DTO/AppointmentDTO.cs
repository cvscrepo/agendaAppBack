using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.DTO
{
    public class AppointmentDTO
    {
        public int IdAppointment { get; set; }

        public string NameAppointment { get; set; } = null!;

        public string FirstNameClient { get; set; } = null!;

        public string? LastName { get; set; }

        public int IdServicio { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public string Phone { get; set; } = null!;

        public virtual UserCalendarDTO? CreatedByNavigation { get; set; }

        public virtual ServiceDTO? IdServicioNavigation { get; set; } = null!;
    }
}
