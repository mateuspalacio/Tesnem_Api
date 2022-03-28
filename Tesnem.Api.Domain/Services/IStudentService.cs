using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Services
{
    public interface IStudentService
    {
        Task<StudentResponse> AddStudent(StudentRequest student);
        Task<StudentResponse> UpdateStudent(Guid id, StudentRequest student);
        Task DeleteStudent(Guid id);
        Task<StudentResponse> GetStudentById(Guid id);
    }
}
