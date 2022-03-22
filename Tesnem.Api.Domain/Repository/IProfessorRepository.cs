using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IProfessorRepository
    {
        Task<Professor> AddProfessor(Professor professor);
        Task<Professor> UpdateProfessor(Guid id, Professor professor);
        Task DeleteProfessor(Guid id);
        Task<Professor> GetProfessorById(Guid id);
    }
}
