using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.DTO
{
    public class RolDTO
    {
        public int IdRole { get; set; }

        public string NameRole { get; set; } = null!;

        public virtual ICollection<UserCalendarDTO> UserCalendars { get; } = new List<UserCalendarDTO>();
    }
}
