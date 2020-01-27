using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WolfPackAPI.Models
{
    [Table("Location", Schema = "dbo")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [StringLength(12)]
        public string Number { get; set; }

        [Required]
        [StringLength(30)]
        public string Postcode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public float? Latitude { get; set; }
        public float? Longitude { get; set; }

        [ForeignKey("WolfId")]
        [JsonIgnore]
        public virtual Wolf Wolf { get; set; }

        [JsonIgnore]
        public int WolfId { get; set; }

    }
}
