using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Patient : BaseEntity
    {
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long FileNumber { get; set; }

        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }
    }
}
