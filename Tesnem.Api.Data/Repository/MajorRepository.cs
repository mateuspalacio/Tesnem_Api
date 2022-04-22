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
    public class MajorRepository : IMajorRepository
    {
        private readonly AppDbContext _appDbContext;
        public MajorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProgramMajor> AddMajor(ProgramMajor major)
        {
            var resp = await _appDbContext.Majors.AddAsync(major);
            await _appDbContext.SaveChangesAsync();
            return resp.Entity;
        }

        public async Task DeleteMajor(Guid id)
        {
            var delete = _appDbContext.Majors.FirstOrDefault(x => x.Id == id);
            if (delete != null)
                _appDbContext.Majors.Remove(delete);
            else
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ProgramMajor> GetMajorById(Guid id)
        {
            var major = _appDbContext.Majors.FirstOrDefault(x => x.Id == id);
            return major;
        }

        public async Task<ProgramMajor> UpdateMajor(Guid id, ProgramMajor major)
        {
            var toUpdate = _appDbContext.Majors.FirstOrDefault(y => y.Id == id);
            if (toUpdate != null)
            {
                toUpdate.Name=major.Name;
                toUpdate.Type=major.Type;
                _appDbContext.Update(toUpdate);
            }
            else
                throw new NotFoundException(ExceptionMessages.MajorNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
            return major;
        }
    }
}
