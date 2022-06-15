using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.Models
{
    public class ProgramMajor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProgramType Type { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
