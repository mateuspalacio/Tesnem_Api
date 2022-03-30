using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Services
{
    public interface IEnrollmentService
    {
        Task<EnrollmentResponse> AddEnrollment(EnrollmentRequest enrollment);
        Task<StudentResponse> AddClasses(string enrollmentNumber, AddClassesRequest newClasses);
        Task<EnrollmentResponse> UpdateEnrollment(Guid id, EnrollmentRequest enrollment);
        Task DeleteEnrollment(Guid id);
        Task<EnrollmentResponse> GetEnrollmentById(Guid id);
    }
}
