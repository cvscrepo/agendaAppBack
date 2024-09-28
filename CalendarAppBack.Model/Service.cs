using System;
using System.Collections.Generic;

namespace CalendarAppBack.Model;

public partial class Service
{
    public int IdService { get; set; }

    public string NameService { get; set; } = null!;

    public string DescriptionServicios { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
