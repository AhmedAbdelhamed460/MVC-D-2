using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_D_2.Models


{
    public class WorksOnProject
    {
        //need copmosit PK of This 2 FK
        public string? Hours { get; set; }

        [ForeignKey("Employee")]
        public int EmpSSN { get; set; }
        public virtual Employee? Employees { get; set; }

        [ForeignKey("Project")]
        public int projNum { get; set; }
        public virtual Project? Project { get; set; }




    }
}
