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
    public class EnrollmentRepositoryTests
    {
        private Mock<IEnrollmentRepository> _rep = new Mock<IEnrollmentRepository>();

        [Fact]
        public async Task Should_Add_Enrollment()
        {
            // Arrange
            var enrollmente = new Mock<Enrollment>();
            _rep.Setup(x => x.Add(It.IsAny<Enrollment>())).Returns(Task.FromResult(enrollmente.Object));

            // Act
            var resp = await _rep.Object.Add(enrollmente.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(enrollmente.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Enrollment()
        {
            // Arrange
            var enrollmente = new Mock<Enrollment>();
            _rep.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(enrollmente.Object));

            // Act
            var resp = await _rep.Object.GetById(enrollmente.Object.Id);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(enrollmente.Object, resp);
        }

        [Fact]
        public void Should_Remove_Enrollments()
        {
            // Arrange
            var enrollmente = new Mock<Enrollment>();
            _rep.Setup(x => x.Delete(It.IsAny<Enrollment>())).Returns(Task.FromResult(enrollmente.Object));

            // Act
            var resp = _rep.Object.Delete(enrollmente.Object).IsCompletedSuccessfully;

            // Assert
            Assert.True(resp);
        }

        [Fact]
        public async Task Should_Update_Enrollment()
        {
            // Arrange
            var enrollmente = new Mock<Enrollment>();
            _rep.Setup(x => x.Update(It.IsAny<Enrollment>())).Returns(Task.FromResult(enrollmente.Object));

            // Act
            var resp = await _rep.Object.Update(enrollmente.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(enrollmente.Object, resp);
        }
    }
}
