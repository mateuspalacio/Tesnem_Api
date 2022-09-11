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
    public class CourseRepositoryTests
    {
        private Mock<ICourseRepository> _rep = new Mock<ICourseRepository>();

        [Fact]
        public async Task Should_Add_Course()
        {
            // Arrange
            var course = new Mock<Course>();
            _rep.Setup(x => x.Add(It.IsAny<Course>())).Returns(Task.FromResult(course.Object));

            // Act
            var resp = await _rep.Object.Add(course.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(course.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Course()
        {
            // Arrange
            var course = new Mock<Course>();
            _rep.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(course.Object));

            // Act
            var resp = await _rep.Object.GetById(course.Object.Id);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(course.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Courses()
        {
            // Arrange
            var item = new Mock<Course>();
            var course = new List<Course>() { item.Object };
            _rep.Setup(x => x.GetAllCourses()).Returns(Task.FromResult((IEnumerable<Course>)course));

            // Act
            var resp = await _rep.Object.GetAllCourses();

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(course, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Courses_By_Major()
        {
            // Arrange
            IEnumerable<Course> courses = new Course[]
            {
                new Mock<Course>().Object
            };
            var majorId = Guid.NewGuid();
            _rep.Setup(x => x.GetByProgramId(It.IsAny<Guid>())).Returns(Task.FromResult(courses));

            // Act
            var resp = await _rep.Object.GetByProgramId(majorId);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(courses, resp);
        }

        [Fact]
        public void Should_Remove_Courses()
        {
            // Arrange
            var course = new Mock<Course>();
            _rep.Setup(x => x.Delete(It.IsAny<Course>())).Returns(Task.FromResult(course.Object));

            // Act
            var resp = _rep.Object.Delete(course.Object).IsCompletedSuccessfully;

            // Assert
            Assert.True(resp);
        }

        [Fact]
        public async Task Should_Update_Course()
        {
            // Arrange
            var course = new Mock<Course>();
            _rep.Setup(x => x.Update(It.IsAny<Course>())).Returns(Task.FromResult(course.Object));

            // Act
            var resp = await _rep.Object.Update(course.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(course.Object, resp);
        }
    }
}
