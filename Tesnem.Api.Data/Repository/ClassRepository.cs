

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


            return classroom;
        }
        async public Task<Class> GetByMajorId(Guid majorId)
        {
            var classroom = await _appDbContext.Classes
                .Include(c => c.Course)
                .Include(c => c.Professor)
                .Include(c => c.Students)
                .Include(c => c.Tests)
                .FirstOrDefaultAsync(x => x.Course.Id == majorId);


            return classroom;
        }

    }
}
