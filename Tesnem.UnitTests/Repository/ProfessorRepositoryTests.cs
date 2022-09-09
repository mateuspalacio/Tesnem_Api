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
    public class ProfessorRepositoryTests
    {
        private Mock<IProfessorRepository> _rep = new Mock<IProfessorRepository>();

        [Fact]
        public async Task Should_Add_Professor()
        {
            // Arrange
            var professor = new Mock<Professor>();
            _rep.Setup(x => x.Add(It.IsAny<Professor>())).Returns(Task.FromResult(professor.Object));

            // Act
            var resp = await _rep.Object.Add(professor.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(professor.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Professor()
        {
            // Arrange
            var professor = new Mock<Professor>();
            _rep.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(professor.Object));

            // Act
            var resp = await _rep.Object.GetById(professor.Object.Id);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(professor.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Professors()
        {
            // Arrange
            var item = new Mock<Professor>();
            var professor = new List<Professor>() { item.Object };
            _rep.Setup(x => x.GetAllProfessors()).Returns(Task.FromResult((IEnumerable<Professor>)professor));

            // Act
            var resp = await _rep.Object.GetAllProfessors();

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(professor, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Professors_By_Course()
        {
            // Arrange
            var item = new Mock<Professor>();
            var professor = new List<Professor>() { item.Object };
            var courseId = Guid.NewGuid();
            _rep.Setup(x => x.GetAllProfessorsByCourse(It.IsAny<Guid>())).Returns(Task.FromResult((IEnumerable<Professor>)professor));

            // Act
            var resp = await _rep.Object.GetAllProfessorsByCourse(courseId);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(professor, resp);
        }

        [Fact]
        public void Should_Remove_Professors()
        {
            // Arrange
            var professor = new Mock<Professor>();
            _rep.Setup(x => x.Delete(It.IsAny<Professor>())).Returns(Task.FromResult(professor.Object));

            // Act
            var resp = _rep.Object.Delete(professor.Object).IsCompletedSuccessfully;

            // Assert
            Assert.True(resp);
        }

        [Fact]
        public async Task Should_Update_Professor()
        {
            // Arrange
            var professor = new Mock<Professor>();
            _rep.Setup(x => x.Update(It.IsAny<Professor>())).Returns(Task.FromResult(professor.Object));

            // Act
            var resp = await _rep.Object.Update(professor.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(professor.Object, resp);
        }
    }
}
