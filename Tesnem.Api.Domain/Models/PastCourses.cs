using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class PastCourses
    {
        [Key]
        public Guid Id { get; set; }
        public List<Student> StudentsWhoCompleted { get; set; }
    }
}
