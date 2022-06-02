using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO
{
    public class SimpleCourse
    {
        public string name { get; set; }
        public Guid id { get; set; }
        public int countClasses { get; set; }
        public int countStudents { get; set; }
    }
}
