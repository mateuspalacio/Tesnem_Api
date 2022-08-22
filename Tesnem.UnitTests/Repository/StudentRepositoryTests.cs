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
            // Arrange
            var student = new Mock<Student>();
            _rep.Setup(x => x.Add(It.IsAny<Student>())).Returns(Task.FromResult(student.Object));

            // Act
            var resp = await _rep.Object.Add(student.Object);
            
            // Assert
            Assert.NotNull(resp);
            Assert.Equal(student.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Student()
        {
            // Arrange
            var student = new Mock<Student>();
            _rep.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(student.Object));

            // Act
            var resp = await _rep.Object.GetById(student.Object.Id);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(student.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Students()
        {
            // Arrange
            var item = new Mock<Student>();
            var student = new List<Student>() { item.Object };
            _rep.Setup(x => x.GetAllStudents()).Returns(Task.FromResult((IEnumerable<Student>)student));

            // Act
            var resp = await _rep.Object.GetAllStudents();

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(student, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Students_By_Course()
        {
            // Arrange
            var item = new Mock<Student>();
            var student = new List<Student>() { item.Object };
            var courseId = Guid.NewGuid();
            _rep.Setup(x => x.GetAllStudentsByCourse(It.IsAny<Guid>())).Returns(Task.FromResult((IEnumerable<Student>)student));

            // Act
            var resp = await _rep.Object.GetAllStudentsByCourse(courseId);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(student, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Students_By_Class()
        {
            // Arrange
            var item = new Mock<Student>();
            var student = new List<Student>() { item.Object };
            var classId = Guid.NewGuid();
            _rep.Setup(x => x.GetAllStudentsByClass(It.IsAny<Guid>())).Returns(Task.FromResult((IEnumerable<Student>)student));

            // Act
            var resp = await _rep.Object.GetAllStudentsByClass(classId);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(student, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Students_By_Major()
        {
            // Arrange
            var item = new Mock<Student>();
            var student = new List<Student>() { item.Object };
            var majorId = Guid.NewGuid();
            _rep.Setup(x => x.GetAllStudentsByMajor(It.IsAny<Guid>())).Returns(Task.FromResult((IEnumerable<Student>)student));

            // Act
            var resp = await _rep.Object.GetAllStudentsByMajor(majorId);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(student, resp);
        }

        [Fact]
        public void Should_Remove_Students()
        {
            // Arrange
            var student = new Mock<Student>();
            _rep.Setup(x => x.Delete(It.IsAny<Student>())).Returns(Task.FromResult(student.Object));

            // Act
            var resp = _rep.Object.Delete(student.Object).IsCompletedSuccessfully;

            // Assert
            Assert.True(resp);
        }

        [Fact]
        public async Task Should_Update_Student()
        {
            // Arrange
            var student = new Mock<Student>();
            _rep.Setup(x => x.Update(It.IsAny<Student>())).Returns(Task.FromResult(student.Object));

            // Act
            var resp = await _rep.Object.Update(student.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(student.Object, resp);
        }
    }
}
