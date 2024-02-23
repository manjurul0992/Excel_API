using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Models
{
    public class NCD_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCD_Details_Id { get; set; }

        [ForeignKey("NCD")]
        public int NCD_Id { get; set; }

        [ForeignKey("Patients_Information")]
        public int PatientId { get; set; }

        public virtual NCD? NCD { get; set; }
        public virtual Patients_Information? Patients_Information { get; set; }
    }
}
