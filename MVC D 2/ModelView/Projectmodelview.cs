using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_D_2.ModelView
{
    public class Projectmodelview
    {
        [Key]
        public int Number { get; set; }

        [Required]
        [MinLength(5)]
        public string? Name { get; set; }
        [Required(ErrorMessage = " Location is required")]
        [Remote("validateproject" , "customvalidation",ErrorMessage = "The location must be Cairo, Alexandria or Giza") ]
        public string? Location { get; set; }
        [Compare("Location")]
        public string? confirmLocation { get; set; }


    }
}
