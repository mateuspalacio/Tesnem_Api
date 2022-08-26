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
    public class MajorControllerTest
    {
        private readonly Mock<IMajorService> _fakeService;
        private readonly MajorController _controller;

        public MajorControllerTest()
        {
            _fakeService = new Mock<IMajorService>();
            _controller = new MajorController(_fakeService.Object);

        }
        [Fact]
        public async void AllGet_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            IEnumerable<MajorResponse> testMajorsList = new MajorResponse[]
            {
                new MajorResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Ciência da Computação",
                    Type = Api.Domain.Models.Enums.ProgramType.Graduate,
                    Courses = new List<SimpleCourse>()
                },
                new MajorResponse(),
                new MajorResponse()
            };
            _fakeService.Setup(s =>
                s.GetAllMajors()).ReturnsAsync(testMajorsList);

            // Act
            var functionResult = await _controller.GetAllMajors();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<MajorResponse[]>(okResult.Value);
            Assert.Equal(testMajorsList.Count(), resultValue.Count());
            Assert.Equal(testMajorsList.First().Id, resultValue[0].Id);
        }
        [Fact]
        public async void IdGet_Id_Is_Present_ReturnsOkResult()
        {
            Guid guid = Guid.NewGuid();
            //Arrange
            MajorResponse getMajorTest = new MajorResponse
            {
                Id = guid,
                Name = "Ciência da Computação",
                Type = Api.Domain.Models.Enums.ProgramType.Graduate,
                Courses = new List<SimpleCourse>
                    {
                        new SimpleCourse
                        {
                            id = Guid.NewGuid(),
                            name = "Disciplina 1",
                            countClasses = 1,
                            countStudents = 20,
                        },
                        new SimpleCourse
                        {
                            id = Guid.NewGuid(),
                            name = "Disciplina 2",
                            countClasses = 2,
                            countStudents = 35,
                        }
                    }
            };
            _fakeService.Setup(s =>
            s.GetMajorById(guid)).ReturnsAsync(getMajorTest);

            // Act
            var functionResult = await _controller.GetMajor(guid);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<MajorResponse>(okResult.Value);
            Assert.Equal(getMajorTest.Id, resultValue.Id);
        }
        [Fact]
        public async void Add_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            MajorRequest addMajorRequest = new MajorRequest
            {
                Name = "NewMajor",
                Type = Api.Domain.Models.Enums.ProgramType.Graduate
            };
            MajorResponse addMajorResponse = new MajorResponse
            {
                Id = Guid.NewGuid(),
                Name = "NewMajor",
                Type = Api.Domain.Models.Enums.ProgramType.Graduate,
                Courses = new List<SimpleCourse>()
            };
            _fakeService.Setup(s =>
            s.AddMajor(addMajorRequest)).ReturnsAsync(addMajorResponse);

            //Act
            var functionResult = await _controller.AddMajor(addMajorRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<MajorResponse>(okResult.Value);
            Assert.Equal(addMajorResponse.Id, resultValue.Id);
        }
        [Fact]
        public async void Put_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            MajorRequest updateMajorRequest = new MajorRequest
            {
                Name = "UpdateMajor",
                Type = Api.Domain.Models.Enums.ProgramType.Graduate
            };
            MajorResponse updatedMajorResponse = new MajorResponse
            {
                Id = guid,
                Name = "UpdateMajor",
                Type = Api.Domain.Models.Enums.ProgramType.Graduate,
                Courses = new List<SimpleCourse>
                {
                     new SimpleCourse
                        {
                            id = Guid.NewGuid(),
                            name = "Disciplina 4",
                            countClasses = 1,
                            countStudents = 12,
                        }
                }
            };
            _fakeService.Setup(s =>
            s.UpdateMajor(guid, updateMajorRequest)).ReturnsAsync(updatedMajorResponse);

            //Act
            var functionResult = await _controller.UpdateMajor(guid, updateMajorRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<MajorResponse>(okResult.Value);
            Assert.Equal(updatedMajorResponse.Id, resultValue.Id);
        }
        [Fact]
        public async void Delete_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var functionResult = await _controller.DeleteMajor(guid);

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
            s.DeleteMultipleMajors(deleteList)).ReturnsAsync(deleteList);

            // Act
            var functionResult = await _controller.DeleteMajors(deleteListRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<List<Guid>>(okResult.Value);
            Assert.Equal(deleteList.Count, resultValue.Count);
        }
    }
}
