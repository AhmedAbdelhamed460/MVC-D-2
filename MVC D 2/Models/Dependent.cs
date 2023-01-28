using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC_D_2.Models

{
    public class Dependent
    {
        //Primary is composit key of (EmpSSN, Name)
        public string Name { get; set; }
        public string Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public string Relationship { get; set; }

        [ForeignKey("Employee")]
        public int EmpSSN { get; set; }
        public Employee Employee { get; set; }
    }
}
