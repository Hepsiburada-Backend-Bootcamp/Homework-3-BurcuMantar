namespace Web.Dtos.Patient
{
    public class PatientUpdateDto : BaseDto
    {
        public string LastName { get; set; }
        public string Gender { get; set; }

        public long FileNumber { get; set; }
    }
}
