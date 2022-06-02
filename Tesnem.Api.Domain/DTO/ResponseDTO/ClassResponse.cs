using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.Repository
{
    public class ClassResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Professor Professor { get; set; }
        public Course Course { get; set; }
        public Guid Course_Id { get; set; }
        public List<Test> Tests { get; set; }
        public Days Days { get; set; }
    }
}
