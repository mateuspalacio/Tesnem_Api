using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Services
{
    public interface IProfessorService
    {
        Task<Professor> AddProfessor(ProfessorDto professor);
        Task<Professor> UpdateProfessor(string id, ProfessorDto professor);
        Task DeleteProfessor(string id);
        Task<Professor> GetProfessorById(string id);
    }
}
