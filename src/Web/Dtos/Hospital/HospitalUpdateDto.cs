using System.ComponentModel.DataAnnotations;

namespace Web.Dtos.Hospital
{
    public class HospitalUpdateDto : BaseDto
    {
        [Required]
        public string Address { get; set; }
    }
}
