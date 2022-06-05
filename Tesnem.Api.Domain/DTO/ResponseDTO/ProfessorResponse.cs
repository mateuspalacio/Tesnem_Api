using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class ProfessorResponse : PersonResponse
    {
        public List<SimpleCourse> TeacherOfCourses { get; set; }
        public List<SimpleClass> TeacherOfClasses { get; set; }

    }
}
