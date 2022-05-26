using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Domain.Services
{
     public interface IClassService
    {
        Task<ClassResponse> AddClass(ClassRequest classroom);
        Task<ClassResponse> UpdateClass(Guid id, ClassRequest classroom);
        Task DeleteClass(Guid id);
        Task<ClassResponse> GetClassById(Guid id);
        Task<IEnumerable<ClassResponse>> GetAllClasses();
        Task<IEnumerable<Guid>> DeleteMultipleClasses(List<Guid> classesIds);
    }
}
