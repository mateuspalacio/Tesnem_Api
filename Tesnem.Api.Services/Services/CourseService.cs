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
        private readonly IUnitOfWork _rep;
        private readonly IMapper _mapper;
        public CourseService(IUnitOfWork repository, IMapper mapper)
        {
            _rep = repository;
            _mapper = mapper;
        }
        public async Task<CourseResponse> AddCourse(CourseRequest course)
        {
            var cour = _mapper.Map<Course>(course);
            cour.Program = await _rep.Majors.GetById(cour.Program.Id);
            if (cour.Program.Name == null)
            {
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, cour.Program.Id);
            }
            var resp = await _rep.Courses.Add(cour);
            return _mapper.Map<CourseResponse>(resp);
        }

        public async Task DeleteCourse(Guid id)
        {
            var resp = await _rep.Courses.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            await _rep.Courses.Delete(resp);
        }

        public async Task<IEnumerable<Guid>> DeleteMultipleCourses(List<Guid> CourseIds)
        {
            List<Guid> deletedWithSuccess = new List<Guid>();
            foreach (Guid id in CourseIds)
            {
                var course = await _rep.Courses.GetById(id);
                if (course == null)
                    continue;
                await _rep.Courses.Delete(course);
                deletedWithSuccess.Add(id);
            }
            return deletedWithSuccess;
        }

        public async Task<IEnumerable<CourseResponse>> GetAllCourses()
        {
            var resp = await _rep.Courses.GetAllCourses();
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.NoEntitiesOnDb, " - No items on database.");
            return _mapper.Map<IEnumerable<CourseResponse>>(resp);
        }

        public async Task<CourseResponse> GetCourseById(Guid id)
        {
            var resp = await _rep.Courses.GetById(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<CourseResponse>(resp);
        }

        public async Task<CourseResponse> GetCourseByProgramId(Guid id)
        {
            var resp = await _rep.Courses.GetByProgramId(id);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<CourseResponse>(resp);
        }

        public async Task<CourseResponse> UpdateCourse(Guid id, CourseRequest course)
        {
            var cour = _mapper.Map<Course>(course);
            cour.Id = id;
            cour.Program = await _rep.Majors.GetById(course.ProgramId);
            var courseReqs = new List<Course>();
            foreach (var req in course.Requirement.Requirements)
                courseReqs.Add(await _rep.Courses.GetById(req));
            cour.Requirements.Add(new CourseRequirement()
            {
                Courses = courseReqs,
                Id = Guid.NewGuid()
            });
            var resp = await _rep.Courses.Update(cour);
            if (resp is null)
                throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
            return _mapper.Map<CourseResponse>(resp);
        }
    }
}
