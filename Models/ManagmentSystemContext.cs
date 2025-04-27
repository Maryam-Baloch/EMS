using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMS.Models;

public partial class ManagmentSystemContext : DbContext
{
    public ManagmentSystemContext()
    {
    }

    public ManagmentSystemContext(DbContextOptions<ManagmentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-withered-sun-a4u688db-pooler.us-east-1.aws.neon.tech;Database=Managment System;Username=Managment System_owner;Password=npg_wK2pL0OYabnt");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceRecordId).HasName("attendance_pkey");

            entity.ToTable("attendance");

            entity.Property(e => e.AttendanceRecordId).HasColumnName("attendance_record_id");
            entity.Property(e => e.AttendanceDate).HasColumnName("attendance_date");
            entity.Property(e => e.AttendanceStatus).HasColumnName("attendance_status");
            entity.Property(e => e.CheckInTime).HasColumnName("check_in_time");
            entity.Property(e => e.CheckOutTime).HasColumnName("check_out_time");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("attendance_employee_id_fkey");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.HasIndex(e => e.DepartmentName, "departments_department_name_key").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepartmentName).HasColumnName("department_name");
            entity.Property(e => e.ManagerName).HasColumnName("manager_name");
            entity.Property(e => e.OfficeLocation).HasColumnName("office_location");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => e.EmailAddress, "employees_email_address_key").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.AnnualSalary)
                .HasPrecision(10, 2)
                .HasColumnName("annual_salary");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmailAddress).HasColumnName("email_address");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.JobTitle).HasColumnName("job_title");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employees_department_id_fkey");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryRecordId).HasName("salaries_pkey");

            entity.ToTable("salaries");

            entity.Property(e => e.SalaryRecordId).HasColumnName("salary_record_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.GrossSalary)
                .HasPrecision(10, 2)
                .HasColumnName("gross_salary");
            entity.Property(e => e.NetSalary)
                .HasPrecision(10, 2)
                .HasColumnName("net_salary");
            entity.Property(e => e.PayMonth).HasColumnName("pay_month");
            entity.Property(e => e.PayYear).HasColumnName("pay_year");
            entity.Property(e => e.TotalDeductions)
                .HasPrecision(10, 2)
                .HasColumnName("total_deductions");

            entity.HasOne(d => d.Employee).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("salaries_employee_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
