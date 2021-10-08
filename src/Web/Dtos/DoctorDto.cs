using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Dtos
{
    public class DoctorDto :BaseDto
    {
        

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
