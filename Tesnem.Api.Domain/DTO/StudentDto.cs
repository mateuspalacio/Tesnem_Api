using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO
{
    public class StudentDto
    {
        public string Name { get; set; }
        public PersonalData Data { get; set; }
        public ProgramMajor ProgramMajor { get; set; }
    }
}
