using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Services.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _rep;
        private readonly IMapper _mapper;
        public MajorService(IMajorRepository repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<MajorResponse> AddMajor(MajorRequest major)
        {
            var maj = _mapper.Map<ProgramMajor>(major);
            var resp = await _rep.AddMajor(maj);
            return _mapper.Map<MajorResponse>(resp);
        }

        public async Task DeleteMajor(Guid id)
        {
            await _rep.DeleteMajor(id);
        }

        public async Task<MajorResponse> GetMajorById(Guid id)
        {
            var resp = await _rep.GetMajorById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<MajorResponse>(resp);
        }

        public async Task<MajorResponse> UpdateMajor(Guid id, MajorRequest major)
        {
            var maj = _mapper.Map<ProgramMajor>(major);
            var resp = await _rep.UpdateMajor(id, maj);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<MajorResponse>(resp);
        }
    }
}
