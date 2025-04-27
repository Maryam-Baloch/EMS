using System;
using System.Collections.Generic;

namespace EMS.Models;

public partial class Salary
{
    public string SalaryRecordId { get; set; } = null!;

    public string? EmployeeId { get; set; }

    public string? PayMonth { get; set; }

    public int? PayYear { get; set; }

    public decimal? GrossSalary { get; set; }

    public decimal? TotalDeductions { get; set; }

    public decimal? NetSalary { get; set; }

    public virtual Employee? Employee { get; set; }
}
