using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO
{
    public class PersonDto
    {
        public string Name { get; set; }
        public PersonalDataDto Data { get; set; }
    }
}
