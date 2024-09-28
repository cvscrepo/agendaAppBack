using System;
using System.Collections.Generic;

namespace CalendarAppBack.Model;

public partial class Appointment
{
    public int IdAppointment { get; set; }

    public string NameAppointment { get; set; } = null!;

    public string FirstNameClient { get; set; } = null!;

    public string? LastName { get; set; }

    public int IdServicio { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public string Phone { get; set; } = null!;

    public virtual UserCalendar? CreatedByNavigation { get; set; }

    public virtual Service? IdServicioNavigation { get; set; } = null!;
}
