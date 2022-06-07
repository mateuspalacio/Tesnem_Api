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
        private readonly IUnitOfWork _rep;
        private readonly IMapper _mapper;
        public MajorService(IUnitOfWork repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<MajorResponse> AddMajor(MajorRequest major)
        {
            var maj = _mapper.Map<ProgramMajor>(major);
            var resp = await _rep.Majors.Add(maj);
            return _mapper.Map<MajorResponse>(resp);
        }

        public async Task DeleteMajor(Guid id)
        {
            var resp = await _rep.Majors.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            await _rep.Majors.Delete(resp);
        }

        public async Task<MajorResponse> GetMajorById(Guid id)
        {
            var resp = await _rep.Majors.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            return _mapper.Map<MajorResponse>(resp); ;
        }

        public async Task<MajorResponse> UpdateMajor(Guid id, MajorRequest major)
        {
            var maj = _mapper.Map<ProgramMajor>(major);
            maj.Id = id;
            var resp = await _rep.Majors.Update(id, maj);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            return _mapper.Map<MajorResponse>(resp);
        }
        public async Task<IEnumerable<MajorResponse>> GetAllMajors()
        {
            var resp = await _rep.Majors.GetAllMajors();
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, " - No items on database.");
            return _mapper.Map<IEnumerable<MajorResponse>>(resp);
        }
        public async Task<IEnumerable<Guid>> DeleteMultipleMajors(List<Guid> majorIds)
        {
            List<Guid> deletedWithSuccess = new List<Guid>();
            foreach (Guid id in majorIds)
            {
                var major = await _rep.Majors.GetById(id);
                if (major == null)
                    continue;
                await _rep.Majors.Delete(major);
                deletedWithSuccess.Add(id);
            }
            return deletedWithSuccess;
        }

    }
}
