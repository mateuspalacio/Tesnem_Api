using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class CourseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SimpleMajor Major { get; set; }
        //public List<Student> Students { get; set; }
        //public List<Professor> Professors { get; set; }
        public List<SimpleClass> Classes { get; set; }
        public List<SimpleCourseRequirement> Requirements { get; set; }
    }
}
