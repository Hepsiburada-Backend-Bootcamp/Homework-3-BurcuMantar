using System.ComponentModel.DataAnnotations;

namespace Web.Dtos.Patient
{
    public class PatientDto : BaseDto
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("(M|F|N)", ErrorMessage = "You can enter only one character that is  ' M ' (Male) or ' F '(Female) or ' N ' (Not defined).")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "This area is required and only accept maximum ten number between 0-9 ")]
        public long FileNumber { get; set; }
    }
}
