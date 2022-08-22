using Tesnem.Api.Domain.Services;
using Tesnem.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using System.Net;
using Tesnem.Api.Domain.DTO.RequestDTO;

namespace Tesnem.UnitTests.Controllers
{
    public class CourseControllerTest
    {
        private readonly Mock<ICourseService> _fakeService;
        private readonly CourseController _controller;
        public CourseControllerTest()
        {
            _fakeService = new Mock<ICourseService>();
            _controller = new CourseController(_fakeService.Object);
        }

        [Fact]
        public async void AllGet_WhenCalled_ReturnsOkResult()
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
            IEnumerable<CourseResponse> testCourseList = new CourseResponse[]
            {
                new CourseResponse
                {
                    Id = guidForCourseTest,
                    Name = "Disciplina1",
                    Major = new SimpleMajor
                    {
                        Id = Guid.NewGuid(),
                        Name = "Major1"
                    },
                    Students = simpleStudentsTest,
                    Classes = new List<SimpleClass>
                    {
                        new SimpleClass 
                        { 
                            Id = Guid.NewGuid(),
                            ProfessorId = Guid.NewGuid(),
                            CourseId = guidForCourseTest,
                            Days = Api.Domain.Models.Enums.Days.MoWe,
                            Students = simpleStudentsTest,
                            Code = "ClassCode1",
                            Tests = simpleTestsTest,
                        },
                        new SimpleClass
                        {
                            Id = Guid.NewGuid(),
                            ProfessorId = Guid.NewGuid(),
                            CourseId = guidForCourseTest,
                            Days = Api.Domain.Models.Enums.Days.TuTh,
                            Students = simpleStudentsTest,
                            Code = "ClassCode2",
                            Tests = new List<SimpleTest>()
                        }
                    },
                    Requirements = new List<CourseRequirementResponse>(),
                },
                new CourseResponse
                {
                    Id = new Guid(),
                    Name = "Disciplina2",
                    Major = new SimpleMajor
                    {
                        Id = Guid.NewGuid(),
                        Name = "Major2"
                    },
                    Students = new List<SimpleStudent>(),
                    Classes = new List<SimpleClass>(),
                    Requirements = new List<CourseRequirementResponse>()
                }
            };
            _fakeService.Setup(s =>
                s.GetAllCourses()).ReturnsAsync(testCourseList);

            // Act
            var functionResult = await _controller.GetAllCourses();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<CourseResponse[]>(okResult.Value);
            Assert.Equal(testCourseList.Count(), resultValue.Count());
            Assert.Equal(testCourseList.First().Id, resultValue[0].Id);
            Assert.Equal(testCourseList.First().Name, resultValue[0].Name);
            Assert.Equal(testCourseList.First().Major.Id, resultValue[0].Major.Id);
            Assert.Equal(testCourseList.First().Students.Count, resultValue[0].Students.Count);
            Assert.Equal(testCourseList.First().Students[0].Id, resultValue[0].Students[0].Id);
            Assert.Equal(testCourseList.First().Classes.Count, resultValue[0].Classes.Count);
            Assert.Equal(testCourseList.First().Classes[0].Id, resultValue[0].Classes[0].Id);
            Assert.Equal(testCourseList.First().Classes[0].Students.Count, resultValue[0].Classes[0].Students.Count);
            Assert.Equal(testCourseList.First().Classes[0].Students[0].Id, resultValue[0].Classes[0].Students[0].Id);
            Assert.Equal(testCourseList.First().Classes[0].Tests.Count, resultValue[0].Classes[0].Tests.Count);
            Assert.Equal(testCourseList.First().Classes[0].Tests[0].ClassId, resultValue[0].Classes[0].Tests[0].ClassId);
            Assert.IsType<List<CourseRequirementResponse>>(resultValue[0].Requirements);
        }
        [Fact]
        public async void IdGet_Id_Is_Present_ReturnsOkResult()
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
            CourseResponse testCourse = new CourseResponse
            {
                Id = guidForCourseTest,
                Name = "Disciplina1",
                Major = new SimpleMajor
                {
                    Id = Guid.NewGuid(),
                    Name = "Major1"
                },
                Students = simpleStudentsTest,
                Classes = new List<SimpleClass>
                    {
                        new SimpleClass
                        {
                            Id = Guid.NewGuid(),
                            ProfessorId = Guid.NewGuid(),
                            CourseId = guidForCourseTest,
                            Days = Api.Domain.Models.Enums.Days.MoWe,
                            Students = simpleStudentsTest,
                            Code = "ClassCode1",
                            Tests = simpleTestsTest,
                        },
                        new SimpleClass
                        {
                            Id = Guid.NewGuid(),
                            ProfessorId = Guid.NewGuid(),
                            CourseId = guidForCourseTest,
                            Days = Api.Domain.Models.Enums.Days.TuTh,
                            Students = simpleStudentsTest,
                            Code = "ClassCode2",
                            Tests = new List<SimpleTest>()
                        }
                    },
                Requirements = new List<CourseRequirementResponse>(),
            };
            _fakeService.Setup(s =>
            s.GetCourseById(guidForCourseTest)).ReturnsAsync(testCourse);

            // Act
            var functionResult = await _controller.GetCourseById(guidForCourseTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<CourseResponse>(okResult.Value);
            Assert.Equal(testCourse.Id, resultValue.Id);
            Assert.Equal(testCourse.Name, resultValue.Name);
            Assert.Equal(testCourse.Major.Id, resultValue.Major.Id);
            Assert.Equal(testCourse.Students.Count, resultValue.Students.Count);
            Assert.Equal(testCourse.Students[0].Id, resultValue.Students[0].Id);
            Assert.Equal(testCourse.Classes.Count, resultValue.Classes.Count);
            Assert.Equal(testCourse.Classes[0].Id, resultValue.Classes[0].Id);
            Assert.Equal(testCourse.Classes[0].Tests.Count, resultValue.Classes[0].Tests.Count);
            Assert.Equal(testCourse.Classes[0].Tests[0].ClassId, resultValue.Classes[0].Tests[0].ClassId);
            Assert.Equal(testCourse.Classes[0].Students[0].Id, resultValue.Students[0].Id);
            Assert.Equal(testCourse.Classes[0].Students.Count, resultValue.Classes[0].Students.Count);
            Assert.Equal(testCourse.Classes[0].Students[0].Id, resultValue.Classes[0].Students[0].Id);
        }
        [Fact]
        public async void Add_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid majorId = Guid.NewGuid();
            List<Guid> requirementIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            CourseRequest courseRequest = new CourseRequest
            {
                Name = "new Course",
                Requirement = new CourseRequirementsRequest
                {
                    Requirements = requirementIds
                },
                ProgramId = majorId
            };

            CourseResponse courseResponse = new CourseResponse
            {
                Id = Guid.NewGuid(),
                Name = "new Course",
                Major = new SimpleMajor
                {
                    Id = majorId,
                    Name = "SomeMajor"
                },
                Students = new List<SimpleStudent>(),
                Classes = new List<SimpleClass>(),
                Requirements = new List<CourseRequirementResponse>()
            };
            _fakeService.Setup(s =>
            s.AddCourse(courseRequest)).ReturnsAsync(courseResponse);

            //Act
            var functionResult = await _controller.AddCourse(courseRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<CourseResponse>(okResult.Value);
            Assert.Equal(courseResponse.Id, resultValue.Id);
            Assert.Equal(courseResponse.Name, resultValue.Name);
            Assert.Equal(courseResponse.Major.Id, resultValue.Major.Id);
            Assert.True(!resultValue.Students.Any());
            Assert.True(!resultValue.Classes.Any());
            Assert.True(!resultValue.Requirements.Any());
        } 
        [Fact]
        public async void Put_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid courseToAlterId = Guid.NewGuid();
            Guid majorId = Guid.NewGuid();
            List<Guid> requirementIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            CourseRequest courseRequest = new CourseRequest
            {
                Name = "new Course",
                Requirement = new CourseRequirementsRequest
                {
                    Requirements = requirementIds
                },
                ProgramId = majorId
            };

            CourseResponse courseResponse = new CourseResponse
            {
                Id = courseToAlterId,
                Name = "new Course",
                Major = new SimpleMajor
                {
                    Id = majorId,
                    Name = "SomeMajor"
                },
                Students = new List<SimpleStudent>(),
                Classes = new List<SimpleClass>(),
                Requirements = new List<CourseRequirementResponse>()
            };
            _fakeService.Setup(s =>
            s.UpdateCourse(courseToAlterId,courseRequest)).ReturnsAsync(courseResponse);

            //Act
            var functionResult = await _controller.UpdateCourse(courseToAlterId,courseRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<CourseResponse>(okResult.Value);
            Assert.Equal(courseResponse.Id, resultValue.Id);
            Assert.Equal(courseResponse.Name, resultValue.Name);
            Assert.Equal(courseResponse.Major.Id, resultValue.Major.Id);
            Assert.True(!resultValue.Students.Any());
            Assert.True(!resultValue.Classes.Any());
            Assert.True(!resultValue.Requirements.Any());
        }
        [Fact]
        public async void Delete_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var functionResult = await _controller.DeleteCourse(guid);

            // Assert
            var okResult = Assert.IsType<NoContentResult>(functionResult);
            Assert.Equal((int)HttpStatusCode.NoContent, (int)okResult.StatusCode);
        }
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
            s.DeleteMultipleCourses(deleteList)).ReturnsAsync(deleteList);

            // Act
            var functionResult = await _controller.DeleteCourses(deleteListRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<List<Guid>>(okResult.Value);
            Assert.Equal(deleteList.Count, resultValue.Count);
        }
    }
}
