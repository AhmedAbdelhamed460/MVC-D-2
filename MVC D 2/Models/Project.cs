using System.ComponentModel.DataAnnotations;
namespace MVC_D_2.Models


{
    public class Project
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public virtual Department? Department { get; set; }


    }
}

