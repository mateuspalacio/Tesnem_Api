using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.Repository
{
    public class ClassResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<SimpleStudent> Students { get; set; }
        public SimpleProfessor Professor { get; set; }
        public SimpleCourse Course { get; set; }
        public Guid CourseId { get; set; }
        public List<SimpleTest> Tests { get; set; }
        public Days Days { get; set; }
    }
}
