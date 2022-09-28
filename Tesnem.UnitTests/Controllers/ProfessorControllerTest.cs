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
    public class ProfessorControllerTest
    {
        private readonly Mock<IProfessorService> _fakeService;
        private readonly ProfessorController _controller;
        public ProfessorControllerTest()
        {
            _fakeService = new Mock<IProfessorService>();
            _controller = new ProfessorController(_fakeService.Object);
        }
        [Fact]
        public async void AllGet_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            IEnumerable<ProfessorResponse> testProfessorList = new ProfessorResponse[]
            {
                new ProfessorResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Professor1",
                    Data = new PersonalDataResponse(),
                    TeacherOfClasses = new List<SimpleClass>(),
                    TeacherOfCourses = new List<SimpleCourse>()
                }, 
                new ProfessorResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Professor2",
                    Data = new PersonalDataResponse(),
                    TeacherOfClasses = new List<SimpleClass>(),
                    TeacherOfCourses = new List<SimpleCourse>()
                },
                new ProfessorResponse()
            };
            _fakeService.Setup(s =>
                s.GetAllProfessors()).ReturnsAsync(testProfessorList);

            // Act
            var functionResult = await _controller.GetAllProfessors();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ProfessorResponse[]>(okResult.Value);
            Assert.Equal(testProfessorList.Count(), resultValue.Count());
            Assert.Equal(testProfessorList.First().Id, resultValue[0].Id);
        }
        [Fact]
        public async void CourseIdGet_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            Guid professorTestId = Guid.NewGuid();
            Guid guidForCourseTest = Guid.NewGuid();
            SimpleCourse courseTest = new SimpleCourse
            {
                id = guidForCourseTest,
                name = "Course1",
                countClasses = 2,
                countStudents = 2
            };
            IEnumerable<ProfessorResponse> testProfessorList = new ProfessorResponse[]
            {
                new ProfessorResponse
                {
                    Id = professorTestId,
                    Name = "Professor 1",
                    Data = new PersonalDataResponse
                    {
                        Id = Guid.NewGuid(),
                        State = "CE",
                        Email = "teste@email.teste",
                        AddressStreet = "AV.Ficticia",
                        AddressHouseNumber = 0123,
                        AdditionalAddress = "Bairro inventado",
                        BirthDate = DateTime.Now,
                        City = "Imaginaria",
                        CPF = "00000000000",
                        Phone = "85999991234"
                    },
                    TeacherOfClasses = new List<SimpleClass>(),
                    TeacherOfCourses = new List<SimpleCourse>
                    {
                        courseTest
                    }
                },
                new ProfessorResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Professor2",
                    Data = new PersonalDataResponse(),
                    TeacherOfClasses = new List<SimpleClass>(),
                    TeacherOfCourses = new List<SimpleCourse>
                    {
                        courseTest
                    }
                }
            };
            _fakeService.Setup(s =>
                s.GetAllProfessorsByCourse(guidForCourseTest)).ReturnsAsync(testProfessorList);

            // Act
            var functionResult = await _controller.GetProfessorsByCourse(guidForCourseTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ProfessorResponse[]>(okResult.Value);
            Assert.Equal(testProfessorList.Count(), resultValue.Count());
            Assert.Equal(testProfessorList.First().Id, resultValue[0].Id);
        }
        [Fact]
        public async void IdGet_Id_Is_Present_ReturnsOkResult()
        {
            //Arrange
            Guid professorTestId = Guid.NewGuid();
            ProfessorResponse profTest = new ProfessorResponse
            {
                Id = professorTestId,
                Name = "Professor 1",
                Data = new PersonalDataResponse
                {
                    Id = Guid.NewGuid(),
                    State = "CE",
                    Email = "teste@email.teste",
                    AddressStreet = "AV.Ficticia",
                    AddressHouseNumber = 0123,
                    AdditionalAddress = "Bairro inventado",
                    BirthDate = DateTime.Now,
                    City = "Imaginaria",
                    CPF = "00000000000",
                    Phone = "85999991234"
                },
                TeacherOfClasses = new List<SimpleClass>(),
                TeacherOfCourses = new List<SimpleCourse>()
            };
            _fakeService.Setup(s =>
                s.GetProfessorById(professorTestId)).ReturnsAsync(profTest);

            // Act
            var functionResult = await _controller.GetProfessor(professorTestId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ProfessorResponse>(okResult.Value);
            Assert.Equal(profTest.Id, resultValue.Id);
        }
        [Fact]
        public async void Add_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            ProfessorRequest addProfRequest = new ProfessorRequest
            {
                Name = "New Professor",
                Data = new PersonalDataRequest
                {
                    State = "CE",
                    Email = "teste@email.teste",
                    AddressStreet = "AV.Ficticia",
                    AddressHouseNumber = 0123,
                    AdditionalAddress = "Bairro inventado",
                    BirthDate = DateTime.Now,
                    City = "Imaginaria",
                    CPF = "00000000000",
                    Phone = "85999991234"
                }
            };
            ProfessorResponse addProfResponse = new ProfessorResponse
            {
                Id = Guid.NewGuid(),
                Name = "New Professor",
                Data = new PersonalDataResponse
                {
                    Id = Guid.NewGuid(),
                    State = "CE",
                    Email = "teste@email.teste",
                    AddressStreet = "AV.Ficticia",
                    AddressHouseNumber = 0123,
                    AdditionalAddress = "Bairro inventado",
                    BirthDate = DateTime.Now,
                    City = "Imaginaria",
                    CPF = "00000000000",
                    Phone = "85999991234"
                },
                TeacherOfClasses = new List<SimpleClass>(),
                TeacherOfCourses = new List<SimpleCourse>(),
            };
            _fakeService.Setup(s =>
            s.AddProfessor(addProfRequest)).ReturnsAsync(addProfResponse);

            //Act
            var functionResult = await _controller.AddProfessor(addProfRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ProfessorResponse>(okResult.Value);
            Assert.Equal(addProfResponse.Id, resultValue.Id);
            Assert.Equal(addProfResponse.Name, resultValue.Name);
            Assert.Equal(addProfResponse.Data.Id, resultValue.Data.Id);
            Assert.NotNull(resultValue.TeacherOfClasses);
            Assert.NotNull(resultValue.TeacherOfCourses);
        }
        [Fact]
        public async void Put_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid profGuid = Guid.NewGuid();
            ProfessorRequest addProfRequest = new ProfessorRequest
            {
                Name = "New Professor",
                Data = new PersonalDataRequest
                {
                    State = "CE",
                    Email = "teste@email.teste",
                    AddressStreet = "AV.Ficticia",
                    AddressHouseNumber = 0123,
                    AdditionalAddress = "Bairro inventado",
                    BirthDate = DateTime.Now,
                    City = "Imaginaria",
                    CPF = "00000000000",
                    Phone = "85999991234"
                }
            };
            ProfessorResponse addProfResponse = new ProfessorResponse
            {
                Id = profGuid,
                Name = "New Professor",
                Data = new PersonalDataResponse
                {
                    Id = Guid.NewGuid(),
                    State = "CE",
                    Email = "teste@email.teste",
                    AddressStreet = "AV.Ficticia",
                    AddressHouseNumber = 0123,
                    AdditionalAddress = "Bairro inventado",
                    BirthDate = DateTime.Now,
                    City = "Imaginaria",
                    CPF = "00000000000",
                    Phone = "85999991234"
                },
                TeacherOfClasses = new List<SimpleClass>(),
                TeacherOfCourses = new List<SimpleCourse>(),
            };
            _fakeService.Setup(s =>
            s.AddProfessor(addProfRequest)).ReturnsAsync(addProfResponse);

            //Act
            var functionResult = await _controller.AddProfessor(addProfRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<ProfessorResponse>(okResult.Value);
            Assert.Equal(addProfResponse.Id, resultValue.Id);
            Assert.Equal(addProfResponse.Name, resultValue.Name);
            Assert.Equal(addProfResponse.Data.Id, resultValue.Data.Id);
            Assert.NotNull(resultValue.TeacherOfClasses);
            Assert.NotNull(resultValue.TeacherOfCourses);
        }
        [Fact]
        public async void Delete_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var functionResult = await _controller.DeleteProfessor(guid);

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
            s.DeleteMultipleProfessors(deleteList)).ReturnsAsync(deleteList);

            // Act
            var functionResult = await _controller.DeleteProfessors(deleteListRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<List<Guid>>(okResult.Value);
            Assert.Equal(deleteList.Count, resultValue.Count);
        }
    }

}
