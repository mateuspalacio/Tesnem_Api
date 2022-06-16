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
        public string Code { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Course Course { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Test> Tests { get; set; } = new List<Test>();
        public Days Days { get; set; }
    }
}
