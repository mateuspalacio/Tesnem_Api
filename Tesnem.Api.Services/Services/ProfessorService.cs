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
        private readonly IProfessorRepository _rep;
        private readonly IMapper _mapper;
        public ProfessorService(IProfessorRepository repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<ProfessorResponse> AddProfessor(ProfessorRequest professor)
        {
            var prof = _mapper.Map<Professor>(professor);
            var resp = await _rep.AddProfessor(prof);
            return _mapper.Map<ProfessorResponse>(resp);
        }

        public async Task DeleteProfessor(Guid id)
        {
            await _rep.DeleteProfessor(id);
        }

        public async Task<ProfessorResponse> GetProfessorById(Guid id)
        {
            var resp = await _rep.GetProfessorById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<ProfessorResponse>(resp);
        }

        public async Task<ProfessorResponse> UpdateProfessor(Guid id, ProfessorRequest professor)
        {
            var prof = _mapper.Map<Professor>(professor);
            var resp = await _rep.UpdateProfessor(id, prof);
            return _mapper.Map<ProfessorResponse>(resp);
        }
    }
}
