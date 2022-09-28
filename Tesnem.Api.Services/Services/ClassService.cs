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
            clas.Course = await _rep.Courses.GetById(clas.Course.Id);
            if (string.IsNullOrEmpty(clas.Course.Name))
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, clas.Course.Id);
            clas.Professor = await _rep.Professors.GetById(clas.Professor.Id);
            if (string.IsNullOrEmpty(clas.Professor.Name))
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, clas.Professor.Id);
            clas.Code = MakeCodeForClass(clas.Course.Id);
            var resp = await _rep.Classes.Add(clas);
            var response = _mapper.Map<ClassResponse>(resp);
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
        public async Task<IEnumerable<ClassResponse>> GetClassByCourseId(Guid courseId)
        {
            var resp = await _rep.Classes.GetByCourseId(courseId);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.ClassNotFoundMessage, courseId);
            return _mapper.Map<IEnumerable<ClassResponse>>(resp);
        }

        public async Task<ClassResponse> UpdateClass(Guid id, ClassRequest classroom)
        {
            var clas = _mapper.Map<Class>(classroom);
            clas.Id = id;
            clas.Professor = await _rep.Professors.GetById(classroom.ProfessorId);
            if(clas.Professor is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, classroom.ProfessorId);
            clas.Course = await _rep.Courses.GetById(classroom.CourseId);
            if (clas.Course is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, classroom.CourseId);
            var resp = await _rep.Classes.Update(clas);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<ClassResponse>(resp);
        }

        public async Task<IEnumerable<ClassResponse>> GetClassByMajorId(Guid Id)
        {
            var resp = await _rep.Classes.GetByMajorId(Id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.ClassNotFoundMessage, Id);
            return _mapper.Map<IEnumerable<ClassResponse>>(resp);
        }
        private static string MakeCodeForClass(Guid CourseId)
        {
            Random rand = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, 5)
                .Select(x => pool[rand.Next(0, pool.Length)]);
            return new string(chars.ToArray() + CourseId.ToString().Substring(0, 3) + DateTime.Now.Day.ToString());
        }
    }
}
