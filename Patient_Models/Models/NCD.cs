using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Models
{
    public class NCD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCD_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NCD_Name { get; set; } = null!;

        public virtual ICollection<NCD_Details>? NCD_Details { get; } = new List<NCD_Details>();
    }
}
