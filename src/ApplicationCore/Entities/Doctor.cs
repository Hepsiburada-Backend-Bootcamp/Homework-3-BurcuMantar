using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Doctor : BaseEntity
    {
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Clinic { get; set; }

        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }
    }
}
