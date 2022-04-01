using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class StudentResponse : PersonResponse
    {
        public MajorResponse ProgramMajor { get; set; }

        //public List<Class> Classes { get; set; }
    }
}
