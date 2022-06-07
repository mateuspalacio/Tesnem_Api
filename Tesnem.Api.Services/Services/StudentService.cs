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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _rep;
        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        // One DTO for response, one for request. This way we can manipulate which items are sent back and received and don't overshare information.
        public async Task<StudentResponse> AddStudent (StudentRequest student)
        {
            var stu = _mapper.Map<Student>(student);
            var resp = await _rep.Students.Add(stu);
            return _mapper.Map<StudentResponse>(resp);
        }

        public async Task<IEnumerable<Guid>> DeleteMultipleStudents(List<Guid> studentIds)
        {
            List<Guid> deletedWithSuccess = new List<Guid>();
            foreach (Guid id in studentIds)
            {
                var student = await _rep.Students.GetById(id);
                if (student == null)
                    continue;
                await _rep.Students.Delete(student);
                deletedWithSuccess.Add(id);
            }
            return deletedWithSuccess;
        }

        public async Task DeleteStudent(Guid id)
        {
            var resp = await _rep.Students.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            await _rep.Students.Delete(resp);
        }

        public async Task<IEnumerable<StudentResponse>> GetAllStudents()
        {
            var resp = await _rep.Students.GetAllStudents();
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, " - No items on database.");
            return _mapper.Map<IEnumerable<StudentResponse>>(resp);
        }

        public async Task<IEnumerable<StudentResponse>> GetAllStudentsByClass(Guid classId)
        {
            var resp = await _rep.Students.GetAllStudentsByClass (classId);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, classId);
            return _mapper.Map<IEnumerable<StudentResponse>>(resp);
        }

        public async Task<IEnumerable<StudentResponse>> GetAllStudentsByCourse(Guid courseId)
        {
            var resp = await _rep.Students.GetAllStudentsByCourse(courseId);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, courseId);
            return _mapper.Map<IEnumerable<StudentResponse>>(resp);
        }
        public async Task<IEnumerable<StudentResponse>> GetAllStudentsByMajor(Guid majorId)
        {
            var resp = await _rep.Students.GetAllStudentsByMajor(majorId);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, majorId);
            return _mapper.Map<IEnumerable<StudentResponse>>(resp);
        }

        public async Task<StudentResponse> GetStudentById(Guid id)
        {
            var resp = await _rep.Students.GetById(id);
            if(resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<StudentResponse>(resp);
        }

        public async Task<StudentResponse> UpdateStudent(Guid id, StudentRequest student)
        {
            var stu = _mapper.Map<Student>(student);
            stu.Id = id;
            var resp = await _rep.Students.Update(id, stu);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<StudentResponse>(resp);
        }
    }
}
