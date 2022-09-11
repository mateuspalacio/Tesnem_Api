using Tesnem.Api.Domain.Services;
using Tesnem.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using System.Net;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.DTO;

namespace Tesnem.UnitTests.Controllers
{
    public class EnrollmentControllerTest
    {
        private readonly Mock<IEnrollmentService> _fakeService;
        private readonly EnrollmentController _controller;
        public EnrollmentControllerTest()
        {
            _fakeService = new Mock<IEnrollmentService>();
            _controller = new EnrollmentController(_fakeService.Object);
        }
        [Fact]
        public async void IdGet_Id_Is_Present_ReturnsOkResult()
        {
            //Arrange
            Guid idGet = Guid.NewGuid();
            EnrollmentResponse enrollment = new EnrollmentResponse
            {
                PersonID = Guid.NewGuid(),
                EnrollmentNumber = "1234567890"
            };

            _fakeService.Setup(s =>
                s.GetEnrollmentById(idGet)).ReturnsAsync(enrollment);

            // Act
            var functionResult = await _controller.GetEnrollment(idGet);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<EnrollmentResponse>(okResult.Value);
            Assert.Equal(enrollment.PersonID, resultValue.PersonID);
            Assert.Equal(enrollment.EnrollmentNumber, resultValue.EnrollmentNumber);            
        }
        [Fact]
        public async void Add_Good_Request_ReturnsOkResult()
        {
            EnrollmentRequest request = new EnrollmentRequest
            {
                PersonID = Guid.NewGuid(),
            };
            EnrollmentResponse response = new EnrollmentResponse
            {
                PersonID = request.PersonID,
                EnrollmentNumber = "1234567890"
            };

            _fakeService.Setup(s =>
                s.AddEnrollment(request)).ReturnsAsync(response);

            // Act
            var functionResult = await _controller.AddEnrollment(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<EnrollmentResponse>(okResult.Value);
            Assert.Equal(response.PersonID, resultValue.PersonID);
            Assert.Equal(response.EnrollmentNumber, resultValue.EnrollmentNumber);
        }
        [Fact]
        public async void Delete_Good_Request_ReturnsOkResult()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var functionResult = await _controller.DeleteEnrollment(guid);

            // Assert
            var okResult = Assert.IsType<NoContentResult>(functionResult);
            Assert.Equal((int)HttpStatusCode.NoContent, (int)okResult.StatusCode);
        }
        [Fact]
        public async void Update_Good_Request_ReturnsOkResult()
        {
            var guid = Guid.NewGuid();
            EnrollmentRequest request = new EnrollmentRequest
            {
                PersonID = Guid.NewGuid(),
            };
            EnrollmentResponse response = new EnrollmentResponse
            {
                PersonID = request.PersonID,
                EnrollmentNumber = "1234567890"
            };

            _fakeService.Setup(s =>
                s.UpdateEnrollment(guid,request)).ReturnsAsync(response);

            // Act
            var functionResult = await _controller.UpdateEnrollment(guid,request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<EnrollmentResponse>(okResult.Value);
            Assert.Equal(response.PersonID, resultValue.PersonID);
            Assert.Equal(response.EnrollmentNumber, resultValue.EnrollmentNumber);
        }
        [Fact]
        public async void AddClasses_Good_Request_ReturnsOkResult()
        {
            string enrollNumber = "1234567890";
            AddClassesRequest addClassesRequest = new AddClassesRequest
            {
                Classes = new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }
            };
            StudentResponse student = new StudentResponse
            {
                Id = Guid.NewGuid(),
                CoursesCompletedId = new List<SimpleCourse>{
                    new SimpleCourse
                    {
                        id = Guid.NewGuid(),
                        countClasses=1,
                        countStudents=1,
                        name = "testeComplete"
                    }
                },
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
                Classes = new List<SimpleClass>
                {
                    new SimpleClass
                        {
                            Id = Guid.NewGuid(),
                            CourseId = Guid.NewGuid(),
                            ProfessorId=Guid.NewGuid(),
                            Code="67890",
                            Days = Api.Domain.Models.Enums.Days.MoWe,
                            Students = new List<SimpleStudent>(),
                            Tests = new List<SimpleTest>()
                        },
                    new SimpleClass
                        {
                            Id = addClassesRequest.Classes[0],
                            CourseId = Guid.NewGuid(),
                            ProfessorId=Guid.NewGuid(),
                            Code="67890",
                            Days = Api.Domain.Models.Enums.Days.MoWe,
                            Students = new List<SimpleStudent>(),
                            Tests = new List<SimpleTest>()
                        },
                    new SimpleClass
                        {
                            Id =  addClassesRequest.Classes[1],
                            CourseId = Guid.NewGuid(),
                            ProfessorId=Guid.NewGuid(),
                            Code="67891",
                            Days = Api.Domain.Models.Enums.Days.MoWeFr,
                            Students = new List<SimpleStudent>(),
                            Tests = new List<SimpleTest>()
                        },
                    new SimpleClass
                        {
                            Id = addClassesRequest.Classes[1],
                            CourseId = Guid.NewGuid(),
                            ProfessorId=Guid.NewGuid(),
                            Code="67892",
                            Days = Api.Domain.Models.Enums.Days.TuTh,
                            Students = new List<SimpleStudent>(),
                            Tests = new List<SimpleTest>()
                        },
                },
                CoursesCurrent = new List<SimpleCourse>(),
                Name = "Lucas",
                ProgramMajor = new MajorResponse()
            };

            _fakeService.Setup(s =>
                s.AddClasses(enrollNumber, addClassesRequest)).ReturnsAsync(student);

            // Act
            var functionResult = await _controller.AddClasses(enrollNumber, addClassesRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse>(okResult.Value);
            Assert.Equal(student.Id, resultValue.Id);
            Assert.Equal(student.Classes.Count, resultValue.Classes.Count);
        }
    }
}
