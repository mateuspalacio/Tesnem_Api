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
        private readonly IStudentRepository _rep;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        // One DTO for response, one for request. This way we can manipulate which items are sent back and received and don't overshare information.
        public async Task<StudentResponse> AddStudent (StudentRequest student)
        {
            var stu = _mapper.Map<Student>(student);
            var resp = await _rep.AddStudent(stu);
            return _mapper.Map<StudentResponse>(resp);
        }

        public async Task DeleteStudent(Guid id)
        {
            await _rep.DeleteStudent(id);
        }

        public async Task<StudentResponse> GetStudentById(Guid id)
        {
            var resp = await _rep.GetStudentById(id);
            if(resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<StudentResponse>(resp);
        }

        public async Task<StudentResponse> UpdateStudent(Guid id, StudentRequest student)
        {
            var stu = _mapper.Map<Student>(student);
            var resp = await _rep.UpdateStudent(id, stu);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
            return _mapper.Map<StudentResponse>(resp);
        }
    }
}
