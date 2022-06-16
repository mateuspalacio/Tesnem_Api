using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO.RequestDTO
{
    public class StudentRequest : PersonRequest
    {
        public Guid MajorId { get; set; }
    }
}
