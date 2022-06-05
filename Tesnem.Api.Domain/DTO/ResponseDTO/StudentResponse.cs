using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class StudentResponse : PersonResponse
    {
        public MajorResponse ProgramMajor { get; set; }

        public List<SimpleClass> Classes { get; set; }

        public List<SimpleCourse> CoursesCurrent { get; set; }
        public List<SimpleCourse> CoursesCompletedId { get; set; }
    }
}
