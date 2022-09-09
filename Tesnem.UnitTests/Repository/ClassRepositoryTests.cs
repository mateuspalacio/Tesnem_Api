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
    public class ClassRepositoryTests
    {
        private Mock<IClassRepository> _rep = new Mock<IClassRepository>();

        [Fact]
        public async Task Should_Add_Class()
        {
            // Arrange
            var _class = new Mock<Class>();
            _rep.Setup(x => x.Add(It.IsAny<Class>())).Returns(Task.FromResult(_class.Object));

            // Act
            var resp = await _rep.Object.Add(_class.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(_class.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Class()
        {
            // Arrange
            var _class = new Mock<Class>();
            _rep.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(_class.Object));

            // Act
            var resp = await _rep.Object.GetById(_class.Object.Id);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(_class.Object, resp);
        }

        [Fact]
        public async Task Should_Get_Many_Classs()
        {
            // Arrange
            var item = new Mock<Class>();
            var _class = new List<Class>() { item.Object };
            _rep.Setup(x => x.GetAllClasses()).Returns(Task.FromResult((IEnumerable<Class>)_class));

            // Act
            var resp = await _rep.Object.GetAllClasses();

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(_class, resp);
        }
        [Fact]
        public async Task Should_Get_Many_Class_By_Course()
        {
            // Arrange
            IEnumerable<Class> classes = new Class[]
            {
                new Mock<Class>().Object
            };
            var courseId = Guid.NewGuid();
            _rep.Setup(x => x.GetByCourseId(It.IsAny<Guid>())).Returns(Task.FromResult(classes));

            // Act
            var resp = await _rep.Object.GetByCourseId(courseId);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(classes, resp);
        }
        [Fact]
        public async Task Should_Get_Many_Class_By_Major()
        {
            // Arrange
            IEnumerable<Class> classes = new Class[]
            {
                new Mock<Class>().Object
            };
            var majorId = Guid.NewGuid();
            _rep.Setup(x => x.GetByMajorId(It.IsAny<Guid>())).Returns(Task.FromResult(classes));

            // Act
            var resp = await _rep.Object.GetByMajorId(majorId);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(classes, resp);
        }

        [Fact]
        public void Should_Remove_Classs()
        {
            // Arrange
            var _class = new Mock<Class>();
            _rep.Setup(x => x.Delete(It.IsAny<Class>())).Returns(Task.FromResult(_class.Object));

            // Act
            var resp = _rep.Object.Delete(_class.Object).IsCompletedSuccessfully;

            // Assert
            Assert.True(resp);
        }

        [Fact]
        public async Task Should_Update_Class()
        {
            // Arrange
            var _class = new Mock<Class>();
            _rep.Setup(x => x.Update(It.IsAny<Class>())).Returns(Task.FromResult(_class.Object));

            // Act
            var resp = await _rep.Object.Update(_class.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(_class.Object, resp);
        }
    }
}
