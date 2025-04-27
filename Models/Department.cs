using System;
using System.Collections.Generic;

namespace EMS.Models;

public partial class Department
{
    public string DepartmentId { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string? ManagerName { get; set; }

    public string? OfficeLocation { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
