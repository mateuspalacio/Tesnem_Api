using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Data.Repository
{
    public class ProfessorRepository : IProfessorRepository

    {
        private readonly AppDbContext _appDbContext;
        public ProfessorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Professor> AddProfessor(Professor professor)
        {
            var resp = await _appDbContext.Professors.AddAsync(professor);
            await _appDbContext.SaveChangesAsync();
            return resp.Entity;
        }

        public async Task DeleteProfessor(Guid id)
        {
            var delete = _appDbContext.Professors.FirstOrDefault(x => x.Id == id);
            if (delete != null)
                _appDbContext.Professors.Remove(delete);
            else
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Professor> GetProfessorById(Guid id)
        {
            var prof = _appDbContext.Professors.FirstOrDefault(x => x.Id == id);
            return prof;
        }

        public async Task<Professor> UpdateProfessor(Guid id, Professor professor)
        {
            var toUpdate = _appDbContext.Professors.FirstOrDefault(y => y.Id == id);
            if (toUpdate != null)
            {
                toUpdate.Name = professor.Name;
                toUpdate.Data=professor.Data;
                _appDbContext.Update(toUpdate);
            }
            else
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
            return professor;
        }
    }
}
