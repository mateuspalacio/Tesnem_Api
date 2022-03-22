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
    public class Test
    {
        public Guid Id { get; set; }
        public double Grade { get; set; }
        public AV Av {  get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public Guid Student_Id { get; set; }
    }
}
