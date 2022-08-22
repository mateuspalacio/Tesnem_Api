using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.UnitTests.Repository
{
    public class StudentRepositoryTests
    {
        private Mock<IStudentRepository> _rep = new Mock<IStudentRepository>();

        [Fact]
        public async Task Should_Add_Student()
        {
            var student = new Student()
            {
                Name = "a"
            };

            var resp = await _rep.Object.Add(student);

            Assert.NotNull(resp);
        }
    }
}
