using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Hospital : BaseEntity
    {
        public string Address { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
