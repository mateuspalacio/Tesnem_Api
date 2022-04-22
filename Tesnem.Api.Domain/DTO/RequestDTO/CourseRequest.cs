using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO.RequestDTO
{
    public class CourseRequest
    {
       public string Name { get; set; }
       public CourseRequirementsRequest Requirement { get; set; }
       public Guid Program_Id { get; set; }
    }
}
