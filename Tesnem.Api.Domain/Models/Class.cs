using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.Models
{
    public class Class
    {
        public Guid Id { get; set; }
        public List<Student> Students { get; set; }
        public Professor Professor { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        [ForeignKey("Course")]
        public Guid Course_Id { get; set; }
        public List<Test> Tests { get; set; }
        public Days Days { get; set; }
    }
}
