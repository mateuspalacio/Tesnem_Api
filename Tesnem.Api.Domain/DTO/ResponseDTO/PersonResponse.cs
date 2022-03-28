using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class PersonResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PersonalDataResponse Data { get; set; }
    }
}
