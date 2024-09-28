using System;
using System.Collections.Generic;

namespace CalendarAppBack.Model;

public partial class Rol
{
    public int IdRole { get; set; }

    public string NameRole { get; set; } = null!;

    public virtual ICollection<UserCalendar> UserCalendars { get; } = new List<UserCalendar>();
}
