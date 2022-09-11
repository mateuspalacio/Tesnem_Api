using Tesnem.Api.Domain.Services;
using Tesnem.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using System.Net;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.UnitTests.Controllers
{
    public class ClassControllerTest
    {
        private readonly Mock<IClassService> _fakeService;
        private readonly ClassController _controller;

        public ClassControllerTest()
        {
            _fakeService = new Mock<IClassService>();
            _controller = new ClassController(_fakeService.Object);
        }
        [Fact]
        public async void AllGet_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            IEnumerable<ClassResponse> testClassesList = new ClassResponse[]
            {
                new ClassResponse
                {
                    Id = Guid.NewGuid(),
                    Course = new SimpleCourse(),
                    CourseId = Guid.NewGuid(),
                    Days = Api.Domain.Models.Enums.Days.MoWeFr,
                    Professor = new SimpleProfessor(),
                    Students = new List<SimpleStudent>(),
                    Tests = new List<SimpleTest>()
                },
                new ClassResponse(),
                new ClassResponse(),
            };
            _fakeService.Setup(s =>
                s.GetAllClasses()).ReturnsAsync(testClassesList);

            // Act
            var functionResult = await _controller.GetAllClasses();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ClassResponse[]>(okResult.Value);
            Assert.Equal(testClassesList.Count(), resultValue.Count());
        }
        [Fact]
        public async void MajorGet_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guidMajorTest = Guid.NewGuid();
            IEnumerable<ClassResponse> testClassesList = new ClassResponse[]
            {
                new ClassResponse
                {
                    Id = Guid.NewGuid(),
                    CourseId = Guid.NewGuid(),
                    Days = Api.Domain.Models.Enums.Days.MoWeFr,
                    Professor = new SimpleProfessor(),
                    Students = new List<SimpleStudent>(),
                    Tests = new List<SimpleTest>()
                },
                new ClassResponse(),
                new ClassResponse(),
            };
            _fakeService.Setup(s =>
                s.GetClassByMajorId(guidMajorTest)).ReturnsAsync(testClassesList);

            // Act
            var functionResult = await _controller.GetClassByMajor(guidMajorTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ClassResponse[]>(okResult.Value);
            Assert.Equal(testClassesList.Count(), resultValue.Count());
        }
        [Fact]
        public async void CourseGet_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guidCourseTest = Guid.NewGuid();
            IEnumerable<ClassResponse> testClassesList = new ClassResponse[]
            {
                new ClassResponse
                {
                    Id = Guid.NewGuid(),
                    Course = new SimpleCourse(),
                    CourseId = guidCourseTest,
                    Days = Api.Domain.Models.Enums.Days.MoWeFr,
                    Professor = new SimpleProfessor(),
                    Students = new List<SimpleStudent>(),
                    Tests = new List<SimpleTest>()
                },
                new ClassResponse(),
                new ClassResponse(),
            };
            _fakeService.Setup(s =>
                s.GetClassByCourseId(guidCourseTest)).ReturnsAsync(testClassesList);

            // Act
            var functionResult = await _controller.GetClassByCourse(guidCourseTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ClassResponse[]>(okResult.Value);
            Assert.Equal(testClassesList.Count(), resultValue.Count());
        }
        [Fact]
        public async Task IdGet_Id_Is_Present_ReturnsOkResultAsync()
        {
            //Arrange
            Guid guidClassTest = Guid.NewGuid();
            ClassResponse testeClass = new ClassResponse
            {
                Id = guidClassTest,
                CourseId = Guid.NewGuid(),
                Course = new SimpleCourse(),
                Days = Api.Domain.Models.Enums.Days.MoWe,
                Professor = new SimpleProfessor
                {
                    Id = Guid.NewGuid(),
                    Name = "Marcos Aurélio"
                },
                Students = new List<SimpleStudent>(),
                Tests = new List<SimpleTest>()
            };
            _fakeService.Setup(s =>
            s.GetClassById(guidClassTest)).ReturnsAsync(testeClass);

            // Act
            var functionResult = await _controller.GetClass(guidClassTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ClassResponse>(okResult.Value);
            Assert.Equal(testeClass.Id, resultValue.Id);
        }
        [Fact]
        public async void Add_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid courseGuid = Guid.NewGuid();
            Guid professorGuid = Guid.NewGuid();
            ClassRequest testeClassRequest = new ClassRequest
            {
                CourseId = courseGuid,
                ProfessorId = professorGuid,
                Days = Api.Domain.Models.Enums.Days.MoWeFr
            };
            ClassResponse testeClassResponse = new ClassResponse
            {
                Id = Guid.NewGuid(),
                CourseId = courseGuid,
                Course = new SimpleCourse
                {
                    id = courseGuid,
                    name = "Course1",
                    countClasses = 2,
                    countStudents = 7,
                },
                Days = Api.Domain.Models.Enums.Days.MoWeFr,
                Professor = new SimpleProfessor
                {
                    Id = professorGuid,
                    Name = "Marcos Aurélio"
                },
                Students = new List<SimpleStudent>(),
                Tests = new List<SimpleTest>()
            };
            _fakeService.Setup(s =>
            s.AddClass(testeClassRequest)).ReturnsAsync(testeClassResponse);

            // Act
            var functionResult = await _controller.AddClass(testeClassRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ClassResponse>(okResult.Value);
            Assert.Equal(testeClassResponse.Id, resultValue.Id);
            Assert.Equal(testeClassResponse.CourseId, resultValue.CourseId);
            Assert.Equal(testeClassResponse.Course.id, resultValue.Course.id);
            Assert.Equal(testeClassResponse.Professor.Id, resultValue.Professor.Id);
            Assert.True(!testeClassResponse.Students.Any());
            Assert.True(!testeClassResponse.Tests.Any());
            Assert.Equal(testeClassResponse.Days, resultValue.Days);
        }
        [Fact]
        public async void Put_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid putGuid = Guid.NewGuid();
            Guid courseGuid = Guid.NewGuid();
            Guid professorGuid = Guid.NewGuid();
            ClassRequest testeClassRequest = new ClassRequest
            {
                CourseId = courseGuid,
                ProfessorId = professorGuid,
                Days = Api.Domain.Models.Enums.Days.MoWeFr
            };
            ClassResponse testeClassResponse = new ClassResponse
            {
                Id = putGuid,
                CourseId = courseGuid,
                Course = new SimpleCourse
                {
                    id = courseGuid,
                    name = "Course1",
                    countClasses = 2,
                    countStudents = 7,
                },
                Days = Api.Domain.Models.Enums.Days.MoWeFr,
                Professor = new SimpleProfessor
                {
                    Id = professorGuid,
                    Name = "Marcos Aurélio"
                },
                Students = new List<SimpleStudent>(),
                Tests = new List<SimpleTest>()
            };
            _fakeService.Setup(s =>
            s.UpdateClass(putGuid,testeClassRequest)).ReturnsAsync(testeClassResponse);

            // Act
            var functionResult = await _controller.UpdateClass(putGuid,testeClassRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ClassResponse>(okResult.Value);
            Assert.Equal(testeClassResponse.Id, resultValue.Id);
            Assert.Equal(testeClassResponse.CourseId, resultValue.CourseId);
            Assert.Equal(testeClassResponse.Course.id, resultValue.Course.id);
            Assert.Equal(testeClassResponse.Professor.Id, resultValue.Professor.Id);
            Assert.Equal(testeClassResponse.Days, resultValue.Days);
        }
        [Fact]
        public async void Delete_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var functionResult = await _controller.DeleteClass(guid);

            // Assert
            var okResult = Assert.IsType<NoContentResult>(functionResult);
            Assert.Equal((int)HttpStatusCode.NoContent, (int)okResult.StatusCode);
        }
        [Fact]
        public async Task DeleteList_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            List<Guid> deleteList = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };
            DeleteListRequest deleteListRequest = new DeleteListRequest
            {
                DeleteList = deleteList
            };
            _fakeService.Setup(s =>
            s.DeleteMultipleClasses(deleteList)).ReturnsAsync(deleteList);

            // Act
            var functionResult = await _controller.DeleteClasses(deleteListRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<List<Guid>>(okResult.Value);
            Assert.Equal(deleteList.Count, resultValue.Count);
        }
    }
}
