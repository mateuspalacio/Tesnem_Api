using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO.RequestDTO
{
    public class PersonRequest
    {
        public string Name { get; set; }
        public PersonalDataRequest Data { get; set; }
    }
}
