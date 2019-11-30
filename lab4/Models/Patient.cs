using System.Collections.Generic;

namespace lab4.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientSecondName { get; set; }
        public int PatientAge { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; }


    }
}
