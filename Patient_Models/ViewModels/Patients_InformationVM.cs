using Patient_Models.Enums;
using Patient_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.ViewModels
{
    public class Patients_InformationVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [Required]
        [StringLength(70)]
        public string PatientName { get; set; } = null!;

        public Epilepsy Epilepsy { get; set; }

        [ForeignKey("Disease")]
        public int DiseaseId { get; set; }
        public virtual Disease_Information? Disease_Information { get; set; }

        // Add these properties
        public virtual ICollection<NCD_Details>? NCD_Details { get; set; } = new List<NCD_Details>();
        public virtual ICollection<Allergies_Details>? Allergies_Details { get; set; } = new List<Allergies_Details>();

        // Add DiseaseName property
        [NotMapped]
        public string? DiseaseName => Disease_Information?.DiseaseName;

        // Add NCD_Ids and Allergy_Ids properties
        [NotMapped]
        public List<int>? NCD_Ids => NCD_Details?.Select(nd => nd.NCD_Id).ToList();
        [NotMapped]
        public List<int>? Allergy_Ids => Allergies_Details?.Select(ad => ad.AllergyId).ToList();

        // Add NCD_Names and Allergy_Names properties
        [NotMapped]
        public List<string>? NCD_Names => NCD_Details?.Select(nd => nd.NCD.NCD_Name).ToList();
        [NotMapped]
        public List<string>? Allergy_Names => Allergies_Details?.Select(ad => ad.Allergies.AllergyName).ToList();
    }
}
