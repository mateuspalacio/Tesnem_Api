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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _rep;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<CourseResponse> AddCourse(CourseRequest course)
        {
            var cour = _mapper.Map<Course>(course);
            var resp = await _rep.AddCourse(cour);
            return _mapper.Map<CourseResponse>(resp);
        }

        public async Task DeleteCourse(Guid id)
        {
            await _rep.DeleteCourse(id);
        }

        public async Task<CourseResponse> GetCourseById(Guid id)
        {
            var resp = await _rep.GetCourseById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<CourseResponse>(resp);
        }

        public async Task<CourseResponse> UpdateCourse(Guid id, CourseRequest course)
        {
            var cour = _mapper.Map<Course>(course);
            var resp = await _rep.UpdateCourse(id, cour);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<CourseResponse>(resp);
        }
    }
}
