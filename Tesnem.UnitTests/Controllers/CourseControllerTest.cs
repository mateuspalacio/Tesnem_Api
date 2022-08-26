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
            IEnumerable<CourseResponse> testCourseList = new CourseResponse[]
            {
                new CourseResponse
                {
                    Id = new Guid(),
                    Name = "Disciplina1",
                    Major = new SimpleMajor(),
                    Students = new List<SimpleStudent>(),
                    Classes = new List<SimpleClass>(),
                    Requirements = new List<CourseRequirementResponse>()
                },
                new CourseResponse(),
                new CourseResponse()
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
        }
        [Fact]
        public async void MajorIdGet_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            Guid majorId = Guid.NewGuid();
            SimpleMajor majorSearched = new SimpleMajor
            {
                Id = majorId,
                Name = "MajorSearched"
            };
            IEnumerable<CourseResponse> testCourseList = new CourseResponse[]
            {
                new CourseResponse
                {
                    Id = new Guid(),
                    Name = "Disciplina1",
                    Major = majorSearched,
                    Students = new List<SimpleStudent>(),
                    Classes = new List<SimpleClass>(),
                    Requirements = new List<CourseRequirementResponse>()
                },
                new CourseResponse(),
                new CourseResponse()
            };
            _fakeService.Setup(s =>
                s.GetCourseByProgramId(majorId)).ReturnsAsync(testCourseList);

            // Act
            var functionResult = await _controller.GetCourseByProgramId(majorSearched.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<CourseResponse[]>(okResult.Value);
            Assert.Equal(testCourseList.Count(), resultValue.Count());
        }
        [Fact]
        public async void IdGet_Id_Is_Present_ReturnsOkResult()
        {
            //Arrange
            Guid guidForCourseTest = Guid.NewGuid();
            CourseResponse testCourse = new CourseResponse
            {
                Id = guidForCourseTest,
                Name = "Disciplina1",
                Major = new SimpleMajor(),
                Students = new List<SimpleStudent>(),
                Classes = new List<SimpleClass>(),
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
