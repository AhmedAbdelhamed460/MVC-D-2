// <auto-generated />
using System;
using MVC_D_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCD2.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    partial class CompanyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_D_2.Models.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVC_D_2.Models.DepartmentLocation", b =>
                {
                    b.Property<int>("DeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeptNumber", "Location");

                    b.ToTable("DepartmentLocation");
                });

            modelBuilder.Entity("MVC_D_2.Models.Dependent", b =>
                {
                    b.Property<int>("EmpSSN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpSSN", "Name");

                    b.ToTable("Dependent");
                });

            modelBuilder.Entity("MVC_D_2.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorSSN")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("SupervisorSSN");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MVC_D_2.Models.Project", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int?>("DepartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("DepartmentNumber");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MVC_D_2.Models.WorksOnProject", b =>
                {
                    b.Property<int>("EmpSSN")
                        .HasColumnType("int");

                    b.Property<int>("projNum")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesSSN")
                        .HasColumnType("int");

                    b.Property<string>("Hours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpSSN", "projNum");

                    b.HasIndex("EmployeesSSN");

                    b.HasIndex("projNum");

                    b.ToTable("WorksOnProjects");
                });

            modelBuilder.Entity("MVC_D_2.Models.DepartmentLocation", b =>
                {
                    b.HasOne("MVC_D_2.Models.Department", "Department")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("DeptNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_D_2.Models.Dependent", b =>
                {
                    b.HasOne("MVC_D_2.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("EmpSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MVC_D_2.Models.Employee", b =>
                {
                    b.HasOne("MVC_D_2.Models.Employee", "Supervisor")
                        .WithMany("Employees")
                        .HasForeignKey("SupervisorSSN");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("MVC_D_2.Models.Project", b =>
                {
                    b.HasOne("MVC_D_2.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentNumber");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_D_2.Models.WorksOnProject", b =>
                {
                    b.HasOne("MVC_D_2.Models.Employee", "Employees")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("EmployeesSSN");

                    b.HasOne("MVC_D_2.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("projNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MVC_D_2.Models.Department", b =>
                {
                    b.Navigation("DepartmentLocations");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("MVC_D_2.Models.Employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("Employees");

                    b.Navigation("WorksOnProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
