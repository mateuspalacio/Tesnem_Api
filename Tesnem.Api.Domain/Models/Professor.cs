using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class Professor : Person
    {
        public List<Course> TeacherOfCourses { get; set; } = new List<Course>();
        public List<Class> TeacherOfClasses { get; set; } = new List<Class>();
    }
}
