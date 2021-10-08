using System.ComponentModel.DataAnnotations;

namespace Web.Dtos
{

    public class DoctorUpdateDto : BaseDto
    {
        [Required(ErrorMessage = "This area is required"), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("(M|F|N)", ErrorMessage = "You can enter only one character that is  ' M ' (Male) or ' F '(Female) or ' N ' (Not defined).")]
        public string Gender { get; set; }
        public string Clinic { get; set; }
        public int HospitalId { get; set; }
    }
}
