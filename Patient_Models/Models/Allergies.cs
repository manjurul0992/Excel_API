using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Models
{
    public class Allergies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllergyId { get; set; }

        [Required]
        [StringLength(50)]
        public string AllergyName { get; set; } = null!;

        public virtual ICollection<Allergies_Details>? Allergies_Details { get; } = new List<Allergies_Details>();
    }
}
