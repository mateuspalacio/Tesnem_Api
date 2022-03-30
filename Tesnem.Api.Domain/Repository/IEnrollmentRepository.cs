using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> AddEnrollment(Enrollment enrollment);
        Task<Student> AddClasses(string enrollmentNumber, List<Guid> newClassesIds);
        Task<Enrollment> UpdateEnrollment(Guid id, Enrollment enrollment);
        Task DeleteEnrollment(Guid id);
        Task<Enrollment> GetEnrollmentById(Guid id);
    }
}
