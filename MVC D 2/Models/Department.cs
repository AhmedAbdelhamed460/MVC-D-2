using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC_D_2.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public virtual List<DepartmentLocation>? DepartmentLocations { get; set; }
        public virtual List<Project>? Projects { get; set; }

    }
}
