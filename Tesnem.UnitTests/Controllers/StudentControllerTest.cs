using Tesnem.Api.Domain.Services;
using Tesnem.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using System.Net;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.DTO.ResponseDTO;

namespace Tesnem.UnitTests.Controllers
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> _fakeService;
        private readonly StudentController _controller;

        public StudentControllerTest()
        {
            _fakeService = new Mock<IStudentService>();
            _controller = new StudentController(_fakeService.Object);
        }
        [Fact]
        public async void AllGet_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            IEnumerable<StudentResponse> testStudentsList = new StudentResponse[]
            {
                new StudentResponse
                {
                    Id = Guid.NewGuid(),
                    Data = new PersonalDataResponse(),
                    CoursesCompletedId = new List<SimpleCourse>(),
                    Classes = new List<SimpleClass>(),
                    CoursesCurrent = new List<SimpleCourse>(),
                    Name = "Marcos",
                    ProgramMajor = new MajorResponse()
                },
                new StudentResponse(),
                new StudentResponse(),
            };
            _fakeService.Setup(s =>
                s.GetAllStudents()).ReturnsAsync(testStudentsList);

            // Act
            var functionResult = await _controller.GetAllStudents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse[]>(okResult.Value);
            Assert.Equal(testStudentsList.Count(), resultValue.Count());
        }
        [Fact]
        public async void MajorGet_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guidMajorTest = Guid.NewGuid();
            IEnumerable<StudentResponse> testStudentsList = new StudentResponse[]
            {
                new StudentResponse
                {
                    Id = Guid.NewGuid(),
                    Data = new PersonalDataResponse(),
                    CoursesCompletedId = new List<SimpleCourse>(),
                    Classes = new List<SimpleClass>(),
                    CoursesCurrent = new List<SimpleCourse>(),
                    Name = "Marcos",
                    ProgramMajor = new MajorResponse
                    {
                        Id = guidMajorTest
                    }
                },
                new StudentResponse(),
                new StudentResponse(),
            };
            _fakeService.Setup(s =>
                s.GetAllStudentsByMajor(guidMajorTest)).ReturnsAsync(testStudentsList);

            // Act
            var functionResult = await _controller.GetStudentsByMajor(guidMajorTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse[]>(okResult.Value);
            Assert.Equal(testStudentsList.Count(), resultValue.Count());
        }
        [Fact]
        public async void CourseGet_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guidCourseTest = Guid.NewGuid();
            IEnumerable<StudentResponse> testStudentsList = new StudentResponse[]
           {
                new StudentResponse
                {
                    Id = Guid.NewGuid(),
                    Data = new PersonalDataResponse(),
                    CoursesCompletedId = new List<SimpleCourse>(),
                    Classes = new List<SimpleClass>(),
                    CoursesCurrent = new List<SimpleCourse>
                    {
                        new SimpleCourse
                        {
                            id = guidCourseTest
                        }
                    },
                    Name = "Marcos",
                    ProgramMajor = new MajorResponse()
                },
                new StudentResponse(),
                new StudentResponse(),
           };
            _fakeService.Setup(s =>
                s.GetAllStudentsByCourse(guidCourseTest)).ReturnsAsync(testStudentsList);

            // Act
            var functionResult = await _controller.GetStudentsByCourse(guidCourseTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse[]>(okResult.Value);
            Assert.Equal(testStudentsList.Count(), resultValue.Count());
        }
        [Fact]
        public async void ClassGet_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guidClassTest = Guid.NewGuid();
            IEnumerable<StudentResponse> testStudentsList = new StudentResponse[]
           {
                new StudentResponse
                {
                    Id = Guid.NewGuid(),
                    Data = new PersonalDataResponse(),
                    CoursesCompletedId = new List<SimpleCourse>(),
                    Classes = new List<SimpleClass>
                    {
                        new SimpleClass
                        {
                            Id = guidClassTest
                        }
                    },
                    CoursesCurrent = new List<SimpleCourse>(),
                    Name = "Marcos",
                    ProgramMajor = new MajorResponse()
                },
                new StudentResponse(),
                new StudentResponse(),
           };
            _fakeService.Setup(s =>
                s.GetAllStudentsByClass(guidClassTest)).ReturnsAsync(testStudentsList);

            // Act
            var functionResult = await _controller.GetStudentsByClass(guidClassTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse[]>(okResult.Value);
            Assert.Equal(testStudentsList.Count(), resultValue.Count());
        }
        [Fact]
        public async Task IdGet_Id_Is_Present_ReturnsOkResultAsync()
        {
            //Arrange
            Guid guidStudentTest = Guid.NewGuid();
            StudentResponse testeStudent = new StudentResponse
            {
                Id = guidStudentTest,
                Data = new PersonalDataResponse(),
                CoursesCompletedId = new List<SimpleCourse>(),
                Classes = new List<SimpleClass>(),
                CoursesCurrent = new List<SimpleCourse>(),
                Name = "Marcos",
                ProgramMajor = new MajorResponse()
            };
            _fakeService.Setup(s =>
            s.GetStudentById(guidStudentTest)).ReturnsAsync(testeStudent);

            // Act
            var functionResult = await _controller.GetStudent(guidStudentTest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse>(okResult.Value);
            Assert.Equal(testeStudent.Id, resultValue.Id);
        }
        [Fact]
        public async void Add_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            StudentRequest stuRequest = new StudentRequest
            {
                MajorId = Guid.NewGuid(),
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
                },
                Name = "Marcos"
            };
            StudentResponse testeStudent = new StudentResponse
            {
                Id = Guid.NewGuid(),
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
                CoursesCompletedId = new List<SimpleCourse>(),
                Classes = new List<SimpleClass>(),
                CoursesCurrent = new List<SimpleCourse>(),
                Name = "Marcos",
                ProgramMajor = new MajorResponse
                {
                    Id = stuRequest.MajorId
                }
            };
            _fakeService.Setup(s =>
            s.AddStudent(stuRequest)).ReturnsAsync(testeStudent);

            // Act
            var functionResult = await _controller.AddStudent(stuRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse>(okResult.Value);
            Assert.Equal(testeStudent.Id, resultValue.Id);
            Assert.Equal(testeStudent.Name, resultValue.Name);
            Assert.IsType<PersonalDataResponse>(resultValue.Data);
            Assert.NotNull(testeStudent.Data);
            Assert.IsType<List<SimpleCourse>>(resultValue.CoursesCurrent);
            Assert.NotNull(testeStudent.CoursesCurrent);
            Assert.IsType<List<SimpleCourse>>(resultValue.CoursesCompletedId);
            Assert.NotNull(testeStudent.CoursesCompletedId);
            Assert.IsType<List<SimpleClass>>(resultValue.Classes);
            Assert.NotNull(testeStudent.Classes);
            Assert.IsType<MajorResponse>(resultValue.ProgramMajor);
            Assert.NotNull(testeStudent.ProgramMajor);
        }
        [Fact]
        public async void Put_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid putGuid = Guid.NewGuid();
            StudentRequest stuRequest = new StudentRequest
            {
                MajorId = Guid.NewGuid(),
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
                },
                Name = "Marcos"
            };
            StudentResponse testeStudent = new StudentResponse
            {
                Id = putGuid,
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
                CoursesCompletedId = new List<SimpleCourse>(),
                Classes = new List<SimpleClass>(),
                CoursesCurrent = new List<SimpleCourse>(),
                Name = "Marcos",
                ProgramMajor = new MajorResponse
                {
                    Id = stuRequest.MajorId
                }
            };
            _fakeService.Setup(s =>
            s.UpdateStudent(putGuid,stuRequest)).ReturnsAsync(testeStudent);

            // Act
            var functionResult = await _controller.UpdateStudent(putGuid,stuRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<StudentResponse>(okResult.Value);
            Assert.Equal(testeStudent.Id, resultValue.Id);
            Assert.Equal(testeStudent.Name, resultValue.Name);
            Assert.IsType<PersonalDataResponse>(resultValue.Data);
            Assert.NotNull(testeStudent.Data);
            Assert.IsType<List<SimpleCourse>>(resultValue.CoursesCurrent);
            Assert.NotNull(testeStudent.CoursesCurrent);
            Assert.IsType<List<SimpleCourse>>(resultValue.CoursesCompletedId);
            Assert.NotNull(testeStudent.CoursesCompletedId);
            Assert.IsType<List<SimpleClass>>(resultValue.Classes);
            Assert.NotNull(testeStudent.Classes);
            Assert.IsType<MajorResponse>(resultValue.ProgramMajor);
            Assert.NotNull(testeStudent.ProgramMajor);
        }
        [Fact]
        public async void Delete_GoodRequest_ReturnsOkResult()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var functionResult = await _controller.DeleteStudent(guid);

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
            s.DeleteMultipleStudents(deleteList)).ReturnsAsync(deleteList);

            // Act
            var functionResult = await _controller.DeleteStudents(deleteListRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(functionResult.Result as OkObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, (int)okResult.StatusCode);
            var resultValue = Assert.IsType<List<Guid>>(okResult.Value);
            Assert.Equal(deleteList.Count, resultValue.Count);
        }
    }
}
