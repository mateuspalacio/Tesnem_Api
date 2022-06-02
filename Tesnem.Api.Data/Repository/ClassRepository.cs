

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
            var classes = _appDbContext.Classes.ToList();
            return classes;
        }

        //public async Task<Class> AddClass(Class classroom)
        //{
        //    classroom.Professor = _appDbContext.Professors.FirstOrDefault(x => x.Id == classroom.Professor.Id);
        //    classroom.Course = _appDbContext.Courses.FirstOrDefault(x => x.Id == classroom.Course.Id);
        //    var resp = await _appDbContext.Classes.AddAsync(classroom);
        //    await _appDbContext.SaveChangesAsync();
        //    return resp.Entity;
        //}

        //public async Task DeleteClass(Guid id)
        //{
        //    var delete = _appDbContext.Classes.FirstOrDefault(x => x.Id == id);
        //    if (delete != null)
        //        _appDbContext.Classes.Remove(delete);
        //    else
        //        throw new NotFoundException(ExceptionMessages.CourseNotFoundMessage, id);
        //    await _appDbContext.SaveChangesAsync();
        //}

        async override public Task<Class> GetById(Guid id)
        {
           var classroom = _appDbContext.Classes.FirstOrDefault(x => x.Id == id);

            return classroom;
        }
        async public Task<Class> GetByCourseId(Guid courseId)
        {
            var classroom = _appDbContext.Classes.FirstOrDefault(x => x.Course_Id == courseId);

            return classroom;
        }

        //public async Task<Class> UpdateClass(Guid id, Class classroom)
        //{
        //    var toUpdate = _appDbContext.Classes.FirstOrDefault(y => y.Id == id);
        //    if (toUpdate != null)
        //    {
        //        toUpdate.Professor = _appDbContext.Professors.FirstOrDefault(x => x.Id == classroom.Professor.Id);
        //        toUpdate.Course = _appDbContext.Courses.FirstOrDefault(x => x.Id == classroom.Course.Id);
        //        toUpdate.Days = classroom.Days;
        //        _appDbContext.Update(toUpdate);
        //    }
        //    else
        //        throw new NotFoundException(ExceptionMessages.PersonNotFoundMessage, id);
        //    await _appDbContext.SaveChangesAsync();
        //    return classroom;
        //}

    }
}
