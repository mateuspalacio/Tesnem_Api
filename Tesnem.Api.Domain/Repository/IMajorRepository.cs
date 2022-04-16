using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Repository
{
    public interface IMajorRepository
    {
        Task<ProgramMajor> AddMajor(ProgramMajor major);
        Task<ProgramMajor> UpdateMajor(Guid id, ProgramMajor major);
        Task DeleteMajor(Guid id);
        Task<ProgramMajor> GetMajorById(Guid id);
    }
}
