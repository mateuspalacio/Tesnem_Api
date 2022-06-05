using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Auth;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Request mapping
            CreateMap<Enrollment, EnrollmentRequest>().ReverseMap();
            CreateMap<Course, CourseRequest>().ReverseMap();
            CreateMap<List<Guid>, AddClassesRequest>().ReverseMap();
            CreateMap<Student, StudentRequest>().ReverseMap();
            CreateMap<Professor, ProfessorRequest>().ReverseMap();
            CreateMap<PersonalData, PersonalDataRequest>().ReverseMap();
            CreateMap<Person, PersonRequest>().ReverseMap();
            CreateMap<ProgramMajor, MajorRequest>().ReverseMap();
            CreateMap<Class, ClassRequest>().ReverseMap();

            // Simple mapping
            CreateMap<ProgramMajor, SimpleMajor>().ReverseMap();

            CreateMap<Course, SimpleCourse>()
                .ForMember(
                x => x.countClasses,
                opt => opt.MapFrom(x => x.Classes.Count)
                )
                .ForMember(
                x => x.countStudents,
                opt => opt.MapFrom(x => x.Students.Count)
                );

            CreateMap<Class, SimpleClass>().ReverseMap();
            CreateMap<Professor, SimpleProfessor>().ReverseMap();
            CreateMap<Student, SimpleStudent>().ReverseMap();
            CreateMap<Test, SimpleTest>().ReverseMap();


            // Response mapping
            CreateMap<Course, CourseResponse>().ReverseMap();
            CreateMap<Enrollment, EnrollmentResponse>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Professor, ProfessorResponse>().ReverseMap();
            CreateMap<PersonalData, PersonalDataResponse>().ReverseMap();
            CreateMap<Person, PersonResponse>().ReverseMap();
            CreateMap<ProgramMajor, MajorResponse>().ReverseMap();
            CreateMap<Class, ClassResponse>().ReverseMap();

            // registration
            CreateMap<UserRegistration, User>().ReverseMap();
        }
    }
}
