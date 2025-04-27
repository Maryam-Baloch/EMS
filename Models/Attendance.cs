using System;
using System.Collections.Generic;

namespace EMS.Models;

public partial class Attendance
{
    public string AttendanceRecordId { get; set; } = null!;

    public string? EmployeeId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public string? AttendanceStatus { get; set; }

    public TimeOnly? CheckInTime { get; set; }

    public TimeOnly? CheckOutTime { get; set; }

    public virtual Employee? Employee { get; set; }
}
