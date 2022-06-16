using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class CourseRequirement
    {
        [Key]
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; }
    }
}
