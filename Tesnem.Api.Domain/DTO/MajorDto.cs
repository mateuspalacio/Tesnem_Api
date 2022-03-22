using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.DTO
{
    public class MajorDto
    {
        public string Name { get; set; }
        public ProgramType Type { get; set; }
    }
}
