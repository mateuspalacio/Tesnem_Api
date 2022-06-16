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
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository

    {
        private readonly AppDbContext _appDbContext;
        public ProfessorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            var prof = await _appDbContext.Professors
                .Include(e => e.TeacherOfClasses)
                .Include(e => e.TeacherOfCourses)
                .Include(e => e.Data)
                .Include(e => e.Enrollment)
                .ToListAsync();
            return prof;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessorsByCourse(Guid courseId)
        {
            var prof = await _appDbContext.Professors
                 .Include(e => e.TeacherOfClasses)
                .Include(e => e.TeacherOfCourses)
                .Include(e => e.Data)
                .Include(e => e.Enrollment)
                .Where(x => x.TeacherOfCourses.Any(x => x.Id == courseId)).ToListAsync();
            return prof;
        }
        async override public Task<Professor> GetById(Guid id)
        {
            var prof = await _appDbContext.Professors
                .Include(e => e.TeacherOfClasses)
                .Include(e => e.TeacherOfCourses)
                .Include(e => e.Data)
                .Include(e => e.Enrollment)
                .FirstOrDefaultAsync(x => x.Id == id);
            return prof;
        }
    }
}
