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
        public Guid Id { get; set; }
        [ForeignKey("Course")]
        public  Guid CourseId { get; set; }
        public List<Course> Requirements { get; set; }
    }
}
