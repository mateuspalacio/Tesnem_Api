using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Test> Tests { get; set; }
        public List<CourseRequirement> Requirements { get; set; }
        public List<Student> Students { get; set; }
        public List<Professor> Professors { get; set; }
        public List<Class> Classes { get; set; }
        [JsonIgnore]
        public ProgramMajor Program { get; set; }
        [ForeignKey("Program")]
        public Guid Program_Id { get; set; }
        public bool IsActive { get; set; }
    }
}
