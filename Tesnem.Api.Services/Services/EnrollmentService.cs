using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Services.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _rep;
        private readonly IMapper _mapper;
        public EnrollmentService(IUnitOfWork repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> AddClasses(string enrollmentNumber, AddClassesRequest newClasses)
        {
            var classesRequest = newClasses.Classes;
            var resp = await _rep.Enrollments.AddClasses(enrollmentNumber, classesRequest);
            return _mapper.Map<StudentResponse>(resp);
        }

        public async Task<EnrollmentResponse> AddEnrollment(EnrollmentRequest enrollment)
        {
            var enroll = _mapper.Map<Enrollment>(enrollment);
            var resp = await _rep.Enrollments.Add(enroll);
            return _mapper.Map<EnrollmentResponse>(resp);
        }

        public async Task DeleteEnrollment(Guid id)
        {
            var toDelete = await _rep.Enrollments.GetById(id);
            if (toDelete == null)
                throw new NotFoundException(ExceptionMessages.EnrollmentNotFoundMessage, id);
            await _rep.Enrollments.Delete(toDelete);
        }

        public async Task<EnrollmentResponse> GetEnrollmentById(Guid id)
        {
            var resp = await _rep.Enrollments.GetById(id);
            return _mapper.Map<EnrollmentResponse>(resp);
        }

        public async Task<EnrollmentResponse> UpdateEnrollment(Guid id, EnrollmentRequest enrollment)
        {
            var enroll = _mapper.Map<Enrollment>(enrollment);
            enroll.Id = id;
            var resp = await _rep.Enrollments.Update(enroll);
            if (resp == null)
                throw new NotFoundException(ExceptionMessages.EnrollmentNotFoundMessage, id);
            return _mapper.Map<EnrollmentResponse>(resp);
        }
    }
}
