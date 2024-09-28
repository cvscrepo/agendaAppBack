using System;
using System.Collections.Generic;

namespace CalendarAppBack.Model;

public partial class UserCalendar
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

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual Rol? RolNavigation { get; set; }
}
