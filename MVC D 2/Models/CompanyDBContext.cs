using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace MVC_D_2.Models
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext()
        {

        }
        public CompanyDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3M46C9\\AA17;Initial Catalog= CompanyMvc;Integrated Security=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentLocation>().HasKey("DeptNumber", "Location");
            modelBuilder.Entity<WorksOnProject>().HasKey("EmpSSN", "projNum");
            modelBuilder.Entity<Dependent>().HasKey("EmpSSN", "Name");

            modelBuilder.Entity<Employee>().HasOne(s => s.Supervisor).WithMany(e => e.Employees);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DepartmentLocation> DepartmentLocation { get; set; }
        public DbSet<WorksOnProject> WorksOnProjects { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
