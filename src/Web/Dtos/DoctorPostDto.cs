using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Dtos
{
    public class DoctorPostDto 
    {
        [Required(ErrorMessage = "This area is required"), MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("(M|F|N)", ErrorMessage = "You can enter only one character that is  ' M ' (Male) or ' F '(Female) or ' N ' (Not defined).")]
        public string Gender { get; set; }

        public string Clinic { get; set; }

        [Required]
        public int HospitalId { get; set; }
    }
}
