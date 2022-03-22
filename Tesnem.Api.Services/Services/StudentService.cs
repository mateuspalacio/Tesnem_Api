using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
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
        public async Task<Student> AddStudent (StudentDto student)
        {
            var stu = _mapper.Map<Student>(student);
            var resp = await _rep.AddStudent(stu);
            return resp;
        }

        public async Task DeleteStudent(Guid id)
        {
            await _rep.DeleteStudent(id);
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            var resp = await _rep.GetStudentById(id);
            return resp;
        }

        public async Task<Student> UpdateStudent(Guid id, StudentDto student)
        {
            var stu = _mapper.Map<Student>(student);
            var resp = await _rep.UpdateStudent(id, stu);
            return resp;
        }
    }
}
