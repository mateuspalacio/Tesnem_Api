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
    public class MajorRepositoryTests
    {
        private Mock<IMajorRepository> _rep = new Mock<IMajorRepository>();

        [Fact]
        public async Task Should_Add_Major()
        {
            // Arrange
            var major = new Mock<ProgramMajor>();
            _rep.Setup(x => x.Add(It.IsAny<ProgramMajor>())).Returns(Task.FromResult(major.Object));

            // Act
            var resp = await _rep.Object.Add(major.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(major.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Major()
        {
            // Arrange
            var major = new Mock<ProgramMajor>();
            _rep.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(major.Object));

            // Act
            var resp = await _rep.Object.GetById(major.Object.Id);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(major.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Majors()
        {
            // Arrange
            var item = new Mock<ProgramMajor>();
            var major = new List<ProgramMajor>() { item.Object };
            _rep.Setup(x => x.GetAllMajors()).Returns(Task.FromResult((IEnumerable<ProgramMajor>)major));

            // Act
            var resp = await _rep.Object.GetAllMajors();

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(major, resp);
        }

        [Fact]
        public void Should_Remove_Majors()
        {
            // Arrange
            var major = new Mock<ProgramMajor>();
            _rep.Setup(x => x.Delete(It.IsAny<ProgramMajor>())).Returns(Task.FromResult(major.Object));

            // Act
            var resp = _rep.Object.Delete(major.Object).IsCompletedSuccessfully;

            // Assert
            Assert.True(resp);
        }

        [Fact]
        public async Task Should_Update_Major()
        {
            // Arrange
            var major = new Mock<ProgramMajor>();
            _rep.Setup(x => x.Update(It.IsAny<ProgramMajor>())).Returns(Task.FromResult(major.Object));

            // Act
            var resp = await _rep.Object.Update(major.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(major.Object, resp);
        }
    }
}
