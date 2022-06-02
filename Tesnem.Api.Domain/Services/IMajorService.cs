using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;

namespace Tesnem.Api.Domain.Services
{
    public interface IMajorService
    {
        Task<MajorResponse> AddMajor(MajorRequest major);
        Task<MajorResponse> UpdateMajor(Guid id, MajorRequest major);
        Task DeleteMajor(Guid id);
        Task<MajorResponse> GetMajorById(Guid id);
        Task<IEnumerable<Guid>> DeleteMultipleMajors(List<Guid> majorIds);
        Task<IEnumerable<MajorResponse>> GetAllMajors();
    }
}
