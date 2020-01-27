using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPackAPI.Models
{
    [Table("Wolf", Schema = "dbo")]
    public class Wolf
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public EGender Gender { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public virtual Location Location { get; set; }

    }

    public enum EGender
    {
        Male, Female, Other
    }
}
