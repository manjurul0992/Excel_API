using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Models
{
    public class Disease_Information
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseId { get; set; }

        [Required]
        [StringLength(50)]
        public string DiseaseName { get; set; } = null!;

        public virtual ICollection<Patients_Information>? Patients_Information { get; } = new List<Patients_Information>();
    }
}
