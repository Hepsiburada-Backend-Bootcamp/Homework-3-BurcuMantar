using System.ComponentModel.DataAnnotations;

namespace Web.Dtos.Hospital
{
    public class HospitalDto : BaseDto
    {
       

        [Required(ErrorMessage = "This area is required")]
        public string Address { get; set; }
    }
}
