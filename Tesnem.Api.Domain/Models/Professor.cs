using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class Professor : Person
    {
        public List<Course> TeacherOfCourses { get; set; }
        public List<Class> TeacherOfClasses { get; set; }
    }
}
