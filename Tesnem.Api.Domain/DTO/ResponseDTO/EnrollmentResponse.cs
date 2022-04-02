using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class EnrollmentResponse
    {
        public Guid PersonID { get; set; }
        public string EnrollmentNumber { get; set; }
    }
}
