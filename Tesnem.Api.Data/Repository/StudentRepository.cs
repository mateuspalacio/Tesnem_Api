using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Data.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async override Task<Student> Add(Student student)
        {
            Guid id = student.ProgramMajor.Id;
            student.ProgramMajor = _appDbContext.Majors.FirstOrDefault(x => x.Id == student.ProgramMajor.Id);
            if (student.ProgramMajor is null)
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            var resp = await _context.Set<Student>().AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async override Task<Student> Update(Guid Id, Student student)
        {
            Guid id = student.ProgramMajor.Id;
            student.ProgramMajor = _appDbContext.Majors.FirstOrDefault(x => x.Id == student.ProgramMajor.Id);
            if (student.ProgramMajor is null)
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            var resp = _appDbContext.Students.Update(student);
            await _context.SaveChangesAsync();
            return resp.Entity;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = await _appDbContext.Students
                .Include(e => e.Classes)
                .Include(x => x.CoursesCompletedId)
                .Include(e => e.CoursesCurrent)
                .Include(e => e.Enrollment)
                .Include(e => e.ProgramMajor).ToListAsync();
            foreach(var student in students)
            {
                foreach(var classroom in student.Classes)
                {
                    classroom.Tests = await _appDbContext.Tests.Where(x => x.Student.Id == student.Id).ToListAsync();
                }
            }
            return students;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByClass(Guid classId)
        {
            var students = await _appDbContext.Students
                 .Include(e => e.Classes)
                .Include(x => x.CoursesCompletedId)
                .Include(e => e.CoursesCurrent)
                .Include(e => e.Enrollment)
                .Include(e => e.ProgramMajor)
                .Where(x => x.Classes.Any(y => y.Id == classId)).ToListAsync();
            foreach (var student in students)
            {
                foreach (var classroom in student.Classes)
                {
                    classroom.Tests = await _appDbContext.Tests.Where(x => x.Student.Id == student.Id).ToListAsync();
                }
            }
            return students;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByCourse(Guid courseId)
        {
            var students = await _appDbContext.Students
                .Include(e => e.Classes)
                .Include(x => x.CoursesCompletedId)
                .Include(e => e.CoursesCurrent)
                .Include(e => e.Enrollment)
                .Include(e => e.ProgramMajor)
                .Where(x => x.CoursesCurrent.Any(y => y.Id == courseId)).ToListAsync();
            foreach (var student in students)
            {
                foreach (var classroom in student.Classes)
                {
                    classroom.Tests = await _appDbContext.Tests.Where(x => x.Student.Id == student.Id).ToListAsync();
                }
            }
            return students;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByMajor(Guid majorId)
        {
            var students = await _appDbContext.Students
                .Include(e => e.Classes)
                .Include(x => x.CoursesCompletedId)
                .Include(e => e.CoursesCurrent)
                .Include(e => e.Enrollment)
                .Include(e => e.ProgramMajor)
                .Where(x => x.ProgramMajor.Id == majorId).ToListAsync();
            foreach (var student in students)
            {
                foreach (var classroom in student.Classes)
                {
                    classroom.Tests = await _appDbContext.Tests.Where(x => x.Student.Id == student.Id).ToListAsync();
                }
            }
            return students;
        }
        public async override Task<Student> GetById(Guid id)
        {
            var student = await _appDbContext.Students
                .Include(e => e.Classes)
                .Include(x => x.CoursesCompletedId)
                .Include(e => e.CoursesCurrent)
                .Include(e => e.Enrollment)
                .Include(e => e.ProgramMajor)
                .FirstOrDefaultAsync(x => x.Id == id);
            foreach (var classroom in student.Classes)
            {
                classroom.Tests = await _appDbContext.Tests.Where(x => x.Student.Id == student.Id).ToListAsync();
            }
            return student;
        }
    }
}
