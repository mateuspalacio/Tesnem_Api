using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO
{
    public class PersonalDataDto
    {
        public string AddressStreet { get; set; }
        [Required]
        public int AddressHouseNumber { get; set; }
        public string AdditionalAddress { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [MaxLength(11), MinLength(10)]
        [DefaultValue("85999999999")]
        public string Phone { get; set; }
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        public string Email { get; set; }
        [StringLength(11)]
        public string CPF { get; set; }
    }
}
