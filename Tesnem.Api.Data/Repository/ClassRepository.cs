

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
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly AppDbContext _appDbContext;
        public ClassRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            var classes = await _appDbContext.Classes
                .Include(c => c.Course)
                .Include(c => c.Professor)
                .Include(c => c.Students)
                .Include(c => c.Tests)
                .ToListAsync();

            if (!classes.Any())
            {
                throw new NotFoundException(ExceptionMessages.NoEntitiesFoundMessage, "Classes");
            }

            return classes;
        }

        async override public Task<Class> GetById(Guid id)
        {
           var classroom = await _appDbContext.Classes
                .Include(c => c.Course )
                .Include(c => c.Professor)
                .Include(c => c.Students)
                .Include(c => c.Tests)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (classroom == null)
            {
                throw new NotFoundException(ExceptionMessages.ClassNotFoundMessage, id);
            }

            if (classroom.Course == null)
            {
                throw new NotFoundException(ExceptionMessages.CourseNotFoundWithClassMessage, id);
            }

            if (classroom.Professor is null)
            {
                throw new NotFoundException(ExceptionMessages.PersonNotFoundOnMajorOrCourseMessage, classroom.Course.Id);
            }

            return classroom;
        }
        async public Task<Class> GetByCourseId(Guid courseId)
        {
            var classroom = await _appDbContext.Classes
                .Include(c => c.Course)
                .Include(c => c.Professor)
                .Include(c => c.Students)
                .Include(c => c.Tests)
                .FirstOrDefaultAsync(x => x.Course.Id == courseId);

            if(classroom == null)
            {
                throw new NotFoundException(ExceptionMessages.ClassNotFoundForCourseMessage, courseId);
            }

            if(classroom.Professor is null)
            {
                throw new NotFoundException(ExceptionMessages.PersonNotFoundOnMajorOrCourseMessage, courseId);
            }

            return classroom;
        }
        async public Task<Class> GetByMajorId(Guid majorId)
        {
            var classroom = await _appDbContext.Classes
                .Include(c => c.Course)
                .Include(c => c.Professor)
                .Include(c => c.Students)
                .Include(c => c.Tests)
                .FirstOrDefaultAsync(x => x.Course.Program.Id == majorId);

            if (classroom == null)
            {
                throw new NotFoundException(ExceptionMessages.ClassNotFoundForMajorMessage, majorId);
            }

            if (classroom.Course == null)
            {
                throw new NotFoundException(ExceptionMessages.CourseNotFoundWithMajorMessage, majorId);
            }

            if (classroom.Professor is null)
            {
                throw new NotFoundException(ExceptionMessages.PersonNotFoundOnMajorOrCourseMessage, majorId);
            }

            return classroom;
        }

    }
}
