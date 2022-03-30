using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Services.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _rep;
        private readonly IMapper _mapper;
        public EnrollmentService(IEnrollmentRepository repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> AddClasses(string enrollmentNumber, AddClassesRequest newClasses)
        {
            var classesRequest = _mapper.Map<List<Guid>>(newClasses);
            var resp = await _rep.AddClasses(enrollmentNumber, classesRequest);
            return _mapper.Map<StudentResponse>(resp);
        }

        public async Task<EnrollmentResponse> AddEnrollment(EnrollmentRequest enrollment)
        {
            var enroll = _mapper.Map<Enrollment>(enrollment);
            var resp = await _rep.AddEnrollment(enroll);
            return _mapper.Map<EnrollmentResponse>(resp);
        }

        public async Task DeleteEnrollment(Guid id)
        {
            await _rep.DeleteEnrollment(id);
        }

        public async Task<EnrollmentResponse> GetEnrollmentById(Guid id)
        {
            var resp = await _rep.GetEnrollmentById(id);
            return _mapper.Map<EnrollmentResponse>(resp);
        }

        public async Task<EnrollmentResponse> UpdateEnrollment(Guid id, EnrollmentRequest enrollment)
        {
            var enroll = _mapper.Map<Enrollment>(enrollment);
            var resp = await _rep.UpdateEnrollment(id, enroll);
            return _mapper.Map<EnrollmentResponse>(resp);
        }
    }
}
