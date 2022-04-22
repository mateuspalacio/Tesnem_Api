using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO.RequestDTO
{
    public class CourseRequirementsRequest
    {
        public List<Guid> Requirements { get; set; }
    }
}
