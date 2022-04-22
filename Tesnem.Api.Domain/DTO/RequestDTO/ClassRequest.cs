using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.DTO.RequestDTO
{
    public class ClassRequest
    { 
        public Guid ProfessorId { get; set; }
        public Guid CourseId { get; set; }
        public Days Days { get; set; }
    }
}
