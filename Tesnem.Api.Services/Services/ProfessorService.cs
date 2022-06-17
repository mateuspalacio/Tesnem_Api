using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Services.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IUnitOfWork _rep;
        private readonly IMapper _mapper;
        public ProfessorService(IUnitOfWork repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<ProfessorResponse> AddProfessor(ProfessorRequest professor)
        {
            var prof = _mapper.Map<Professor>(professor);
            var resp = await _rep.Professors.Add(prof);
            return _mapper.Map<ProfessorResponse>(resp);
        }

        public async Task<IEnumerable<Guid>> DeleteMultipleProfessors(List<Guid> professorIds)
        {
            List<Guid> deletedWithSuccess = new List<Guid>();
            foreach (Guid id in professorIds)
            {
                var professor = await _rep.Professors.GetById(id);
                if (professor == null)
                    continue;
                await _rep.Professors.Delete(professor);
                deletedWithSuccess.Add(id);
            }
            return deletedWithSuccess;
        }

        public async Task DeleteProfessor(Guid id)
        {
            var resp = await _rep.Professors.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, " - No items on database.");
            await _rep.Professors.Delete(resp);
        }

        public async Task<IEnumerable<ProfessorResponse>> GetAllProfessors()
        {
            var resp = await _rep.Professors.GetAllProfessors();
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, " - No items on database.");
            return _mapper.Map<IEnumerable<ProfessorResponse>>(resp);
        }

        public async Task<IEnumerable<ProfessorResponse>> GetAllProfessorsByCourse(Guid courseId)
        {
            var resp = await _rep.Professors.GetAllProfessorsByCourse(courseId);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, courseId);
            return _mapper.Map<IEnumerable<ProfessorResponse>>(resp);
        }

        public async Task<ProfessorResponse> GetProfessorById(Guid id)
        {
            var resp = await _rep.Professors.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<ProfessorResponse>(resp);
        }

        public async Task<ProfessorResponse> UpdateProfessor(Guid id, ProfessorRequest professor)
        {
            var prof = _mapper.Map<Professor>(professor);
            prof.Id = id;
            var resp = await _rep.Professors.Update(prof);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<ProfessorResponse>(resp);
        }
    }
}
