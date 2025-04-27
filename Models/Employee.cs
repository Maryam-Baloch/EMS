using System;
using System.Collections.Generic;

namespace EMS.Models;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? JobTitle { get; set; }

    public string? DepartmentId { get; set; }

    public DateOnly? HireDate { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public decimal? AnnualSalary { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}
