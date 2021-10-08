using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Dtos.Hospital
{
    public class HospitalPostDto
    {
        [Required(ErrorMessage = "This area is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This area is required")]
        public string Address { get; set; }
    }
}
