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
        private readonly IUnitOfWork _rep;
        private readonly IMapper _mapper;
        public ClassService(IUnitOfWork repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<ClassResponse> AddClass(ClassRequest classroom)
        {
            var clas = _mapper.Map<Class>(classroom);
            var resp = await _rep.Classes.Add(clas);
            var response = _mapper.Map<ClassResponse>(resp);
            response.Students = await _rep.Students.GetAllStudentsByClass(resp.Id);
            response.Professor = await _rep.Professors.GetById(resp.Professor_Id);
            return response;
        }

        public async Task DeleteClass(Guid id)
        {
            var resp = await _rep.Classes.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.ClassNotFoundMessage, id);
            await _rep.Classes.Delete(resp);
        }

        public async Task<IEnumerable<Guid>> DeleteMultipleClasses(List<Guid> classesIds)
        {
            List<Guid> deletedWithSuccess = new List<Guid>();
            foreach (Guid id in classesIds)
            {
                var deleteClass = await _rep.Classes.GetById(id);
                if (deleteClass == null)
                    continue;
                await _rep.Classes.Delete(deleteClass);
                deletedWithSuccess.Add(id);
            }
            return deletedWithSuccess;
        }

        public async Task<IEnumerable<ClassResponse>> GetAllClasses()
        {
            var resp = await _rep.Classes.GetAllClasses();
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, " - No items on database.");
            return _mapper.Map<IEnumerable<ClassResponse>>(resp);
        }

        public async Task<ClassResponse> GetClassById(Guid id)
        {
            var resp = await _rep.Classes.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.ClassNotFoundMessage, id);
            return _mapper.Map<ClassResponse>(resp);
        }

        public async Task<ClassResponse> UpdateClass(Guid id, ClassRequest classroom)
        {
            var clas = _mapper.Map<Class>(classroom);
            var resp = await _rep.Classes.Update(id, clas);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<ClassResponse>(resp);
        }
    }
}
