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
    public interface IProfessorService
    {
        Task<ProfessorResponse> AddProfessor(ProfessorRequest professor);
        Task<ProfessorResponse> UpdateProfessor(Guid id, ProfessorRequest professor);
        Task DeleteProfessor(Guid id);
        Task<ProfessorResponse> GetProfessorById(Guid id);
        Task<IEnumerable<ProfessorResponse>> GetAllProfessors();
        Task<IEnumerable<ProfessorResponse>> GetAllProfessorsByCourse(Guid courseId);
    }
}
