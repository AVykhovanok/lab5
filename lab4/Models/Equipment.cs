using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab4.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        [MinLength(5)]
        [MaxLength(20, ErrorMessage = "Name length should be less then 20 characters ")]
        public string EquipmentName { get; set; }


        public virtual ICollection<Procedure> Procedures { get; set; }

    }
}
