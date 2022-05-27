using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class Student : Person
    {
        public List<Course> CoursesCurrent { get; set; }
        public List<PastCourses> CoursesCompletedId { get; set; }
        public List<Class> Classes { get; set; }
        public DateTime ConclusionDate { get; set; }
        public ProgramMajor ProgramMajor { get; set; }
    }
}
