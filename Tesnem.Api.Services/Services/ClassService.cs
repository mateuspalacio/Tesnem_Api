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
    public class ClassService : IClassService
    {
        private readonly IClassRepository _rep;
        private readonly IMapper _mapper;
        public ClassService(IClassRepository repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<ClassResponse> AddClass(ClassRequest classroom)
        {
            var clas = _mapper.Map<Class>(classroom);
            var resp = await _rep.AddClass(clas);
            return _mapper.Map<ClassResponse>(resp);
        }

        public async Task DeleteClass(Guid id)
        {
            await _rep.DeleteClass(id);
        }

        public async Task<ClassResponse> GetClassById(Guid id)
        {
            var resp = await _rep.GetClassById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<ClassResponse>(resp);
        }

        public async Task<ClassResponse> UpdateClass(Guid id, ClassRequest classroom)
        {
            var clas = _mapper.Map<Class>(classroom);
            var resp = await _rep.UpdateClass(id, clas);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<ClassResponse>(resp);
        }
    }
}
