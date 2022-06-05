using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO
{
    public class SimpleClass
    {
        public Guid Id { get; set; }
        public Days Days { get; set; }
        public Guid Professor_Id { get; set; }
        public List<SimpleTest> Tests { get; set; }
        public List<SimpleStudent> Students { get; set; }
    }
}
