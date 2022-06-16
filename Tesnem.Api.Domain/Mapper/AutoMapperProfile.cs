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
            CreateMap<Student, StudentRequest>()
                .ForMember(
                x => x.MajorId,
                opt => opt.MapFrom(x => x.ProgramMajor.Id)
                )
                .ReverseMap();
            CreateMap<Professor, ProfessorRequest>().ReverseMap();
            CreateMap<PersonalData, PersonalDataRequest>().ReverseMap();
            CreateMap<Person, PersonRequest>().ReverseMap();
            CreateMap<ProgramMajor, MajorRequest>().ReverseMap();
            CreateMap<Class, ClassRequest>().ReverseMap();

            // Simple mapping
            CreateMap<ProgramMajor, SimpleMajor>()
                .ForMember(
                x => x.Id,
                opt => opt.MapFrom(x => x.Id)
                )
                .ForMember(
                x => x.Name,
                opt => opt.MapFrom(x => x.Name)
                ).ReverseMap();

            CreateMap<Course, SimpleCourse>()
                .ForMember(
                x => x.countClasses,
                opt => opt.MapFrom(x => x.Classes.Count)
                )
                .ForMember(
                x => x.countStudents,
                opt => opt.MapFrom(x => x.Students.Count)
                );

            CreateMap<Class, SimpleClass>()
                .ForMember(
                x => x.ProfessorId,
                opt => opt.MapFrom(x => x.Professor.Id)
                )
                .ReverseMap();
            CreateMap<Professor, SimpleProfessor>().ReverseMap();
            CreateMap<Student, SimpleStudent>().ReverseMap();
            CreateMap<Test, SimpleTest>().ReverseMap();


            // Response mapping
            CreateMap<Course, CourseResponse>()
                .ForMember(
                    x => x.Major,
                    opt => opt.MapFrom(x => x.Program)
                )
                .ReverseMap();
            CreateMap<Enrollment, EnrollmentResponse>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Professor, ProfessorResponse>().ReverseMap();
            CreateMap<PersonalData, PersonalDataResponse>().ReverseMap();
            CreateMap<Person, PersonResponse>().ReverseMap();
            CreateMap<ProgramMajor, MajorResponse>().ReverseMap();
            CreateMap<Class, ClassResponse>()
                .ForMember(
                    x => x.Professor,
                    opt => opt.MapFrom(x => x.Professor)
                )
                .ForMember(
                    x => x.Course,
                    opt => opt.MapFrom(x => x.Course)
                )
                .ReverseMap();

            // registration
            CreateMap<UserRegistration, User>().ReverseMap();
        }
    }
}
