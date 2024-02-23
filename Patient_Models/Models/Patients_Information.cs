using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Models.Enums;

namespace Patient_Models.Models
{
    public class Patients_Information
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [Required]
        [StringLength(70)]
        public string PatientName { get; set; } = null!;

        //public string Epilepsy { get; set; } = null!;
        public Epilepsy Epilepsy { get; set; }

        [ForeignKey("Disease_Information")]
        public int DiseaseId { get; set; }
        public virtual Disease_Information? Disease_Information { get; }

        public virtual ICollection<NCD_Details>? NCD_Details { get; } = new List<NCD_Details>();

        public virtual ICollection<Allergies_Details>? Allergies_Details { get; } = new List<Allergies_Details>();
    }
}
