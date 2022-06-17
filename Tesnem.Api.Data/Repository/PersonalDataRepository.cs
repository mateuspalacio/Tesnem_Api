using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Data.Repository
{
    public class PersonalDataRepository : GenericRepository<PersonalData>, IPersonalDataRepository
    {
        public PersonalDataRepository(AppDbContext context) : base(context)
        {
        }
    }
}
