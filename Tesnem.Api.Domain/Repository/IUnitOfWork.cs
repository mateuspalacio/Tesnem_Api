using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRepository Classes { get; }
        ICourseRepository Courses { get; }
        IEnrollmentRepository Enrollments { get; }
        IMajorRepository Majors { get; }
        IProfessorRepository Professors { get; }
        IStudentRepository Students { get; }
        IPersonalDataRepository PersonalData { get; }
        int Complete();
    }
}
