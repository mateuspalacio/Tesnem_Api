using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Services.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _rep;
        public ProfessorService(IProfessorRepository repository)
        {
            _rep = repository;
        }
        public async Task<Professor> AddProfessor(Professor professor)
        {
            var resp = await _rep.AddProfessor(professor);
            return resp;
        }

        public async Task DeleteProfessor(string id)
        {
            await _rep.DeleteProfessor(id);
        }

        public async Task<Professor> GetProfessorById(string id)
        {
            var resp = await _rep.GetProfessorById(id);
            return resp;
        }

        public async Task<Professor> UpdateProfessor(string id, Professor professor)
        {
            var resp = await _rep.UpdateProfessor(id, professor);
            return resp;
        }
    }
}
