using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class PersonalData
    {
        [Key]
        [ForeignKey("Person")]
        public string PersonId { get; set; }
        [Required]
        public string AddressStreet { get; set; }
        [Required]
        public int AddressHouseNumber { get; set; }
        public string AdditionalAddress { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [MaxLength(11), MinLength(10)]
        [DefaultValue("85999999999")]
        public string Phone { get; set; }
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        public string Email { get; set; }
        [StringLength(11)]
        public string CPF { get; set; }
        [JsonIgnore]
        public DateTime EntryDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public Person Person { get; set; }
    }
}
