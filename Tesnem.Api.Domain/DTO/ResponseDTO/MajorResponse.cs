using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class MajorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProgramType Type { get; set; }
        public List<SimpleCourse> Courses { get; set; }
        //public List<CourseResponse> Courses { get; set; }
    }
}
