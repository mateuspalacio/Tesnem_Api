using Tesnem.Api.Domain.Services;
using Tesnem.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tesnem.Api.Domain.DTO.ResponseDTO;
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
            Guid guidForCourseTest = Guid.NewGuid();
            Guid guidClassTest = Guid.NewGuid();
            List<SimpleStudent> simpleStudentsTest = new List<SimpleStudent>
            {
                        new SimpleStudent
                        {
                            Id = Guid.NewGuid(),
                            Name = "Student1"
                        },
                        new SimpleStudent
                        {
                            Id = Guid.NewGuid(),
                            Name = "Student2"
                        }
            };
            List<SimpleTest> simpleTestsTest = new List<SimpleTest>
            {
                new SimpleTest
                {
                    CourseId = guidForCourseTest,
                    ClassId = guidClassTest,
                    StudentId = simpleStudentsTest[0].Id,
                    Av = Api.Domain.Models.Enums.AV.AV1,
                    Grade = 9.2,
                },
                new SimpleTest
                {
                    CourseId = guidForCourseTest,
                    ClassId = guidClassTest,
                    StudentId = simpleStudentsTest[1].Id,
                    Av = Api.Domain.Models.Enums.AV.AV1,
                    Grade = 6.7,
                }
            };
            IEnumerable<ClassResponse> testClassesList = new ClassResponse[]
            {
                new ClassResponse
                {
                    Id = guidClassTest,
                    CourseId = guidForCourseTest,
                    Course = new SimpleCourse
                    {
                        id = guidForCourseTest,
                        name = "Course1",
                        countClasses = 2,
                        countStudents = 7,
                    },
                    Days = Api.Domain.Models.Enums.Days.MoWe,
                    Professor = new SimpleProfessor
                    {
                        Id = Guid.NewGuid(),
                        Name = "Marcos Aurélio"
                    },
                    Students = simpleStudentsTest,
                    Tests = simpleTestsTest
                },
                new ClassResponse
                {
                    Id = Guid.NewGuid(),
                    Course = new SimpleCourse(),
                    CourseId = Guid.NewGuid(),
                    Days = Api.Domain.Models.Enums.Days.MoWeFr,
                    Professor = new SimpleProfessor(),
                    Students = new List<SimpleStudent>(),
                    Tests = new List<SimpleTest>()
                }
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
            Assert.Equal(testClassesList.First().Id, resultValue[0].Id);
            Assert.Equal(testClassesList.First().Days, resultValue[0].Days);
            Assert.Equal(testClassesList.First().CourseId, resultValue[0].CourseId);
            Assert.Equal(testClassesList.First().Course.id, resultValue[0].Course.id);
            Assert.Equal(testClassesList.First().Professor.Id, resultValue[0].Professor.Id);
            Assert.Equal(testClassesList.First().Students.Count(), resultValue[0].Students.Count());
            Assert.Equal(testClassesList.First().Students.First().Id, resultValue[0].Students.First().Id);
            Assert.Equal(testClassesList.First().Tests.Count(), resultValue[0].Tests.Count());
            Assert.Equal(testClassesList.First().Tests.First().ClassId, resultValue[0].Tests.First().ClassId);
        }
        [Fact]
        public async Task IdGet_Id_Is_Present_ReturnsOkResultAsync()
        {
            //Arrange
            Guid guidForCourseTest = Guid.NewGuid();
            Guid guidClassTest = Guid.NewGuid();
            List<SimpleStudent> simpleStudentsTest = new List<SimpleStudent>
            {
                        new SimpleStudent
                        {
                            Id = Guid.NewGuid(),
                            Name = "Student1"
                        },
                        new SimpleStudent
                        {
                            Id = Guid.NewGuid(),
                            Name = "Student2"
                        }
            };
            List<SimpleTest> simpleTestsTest = new List<SimpleTest>
            {
                new SimpleTest
                {
                    CourseId = guidForCourseTest,
                    ClassId = guidClassTest,
                    StudentId = simpleStudentsTest[0].Id,
                    Av = Api.Domain.Models.Enums.AV.AV1,
                    Grade = 9.2,
                },
                new SimpleTest
                {
                    CourseId = guidForCourseTest,
                    ClassId = guidClassTest,
                    StudentId = simpleStudentsTest[1].Id,
                    Av = Api.Domain.Models.Enums.AV.AV1,
                    Grade = 6.7,
                }
            };
            ClassResponse testeClass = new ClassResponse
            {
                Id = guidClassTest,
                CourseId = guidForCourseTest,
                Course = new SimpleCourse
                {
                    id = guidForCourseTest,
                    name = "Course1",
                    countClasses = 2,
                    countStudents = 7,
                },
                Days = Api.Domain.Models.Enums.Days.MoWe,
                Professor = new SimpleProfessor
                {
                    Id = Guid.NewGuid(),
                    Name = "Marcos Aurélio"
                },
                Students = simpleStudentsTest,
                Tests = simpleTestsTest
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
            Assert.Equal(testeClass.CourseId, resultValue.CourseId);
            Assert.Equal(testeClass.Course.id, resultValue.Course.id);
            Assert.Equal(testeClass.Days, resultValue.Days);
            Assert.Equal(testeClass.Professor.Id, resultValue.Professor.Id);
            Assert.Equal(testeClass.Students.Count(), resultValue.Students.Count());
            Assert.Equal(testeClass.Students.First().Id, resultValue.Students.First().Id);
            Assert.Equal(testeClass.Tests.Count(), resultValue.Tests.Count());
            Assert.Equal(testeClass.Tests.First().ClassId, resultValue.Tests.First().ClassId);
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
            Assert.True(!testeClassResponse.Students.Any());
            Assert.True(!testeClassResponse.Tests.Any());
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
