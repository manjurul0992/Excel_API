using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Models
{
    public class Allergies_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Allergies_Details_Id { get; set; }

        [ForeignKey("Patients_Information")]
        public int PatientId { get; set; }

        [ForeignKey("Allergies")]
        public int AllergyId { get; set; }

        public virtual Patients_Information? Patients_Information { get; set; }
        public virtual Allergies? Allergies { get; set; }
    }
}
