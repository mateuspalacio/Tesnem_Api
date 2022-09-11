using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<IEnumerable<Course>> GetByProgramId(Guid programId);
    }
}
