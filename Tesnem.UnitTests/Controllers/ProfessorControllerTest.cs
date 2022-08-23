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
            Guid professorTestId = Guid.NewGuid();
            Guid classTestId = Guid.NewGuid();
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
                    TeacherOfClasses = new List<SimpleClass>
                    {
                        new SimpleClass
                        {
                            Id = classTestId,
                            CourseId = guidForCourseTest,
                            ProfessorId =professorTestId,
                            Code = "12345",
                            Days = Api.Domain.Models.Enums.Days.TuTh,
                            Students = simpleStudentsTest,
                            Tests = simpleTestsTest
                        },
                        new SimpleClass
                        {
                            Id = Guid.NewGuid(),
                            CourseId = guidForCourseTest,
                            ProfessorId=professorTestId,
                            Code="67890",
                            Days = Api.Domain.Models.Enums.Days.MoWe,
                            Students = new List<SimpleStudent>(),
                            Tests = new List<SimpleTest>()
                        }
                    },
                    TeacherOfCourses = new List<SimpleCourse>
                    {
                        new SimpleCourse
                        {
                            id = guidForCourseTest,
                            name = "Course1",
                            countClasses = 2,
                            countStudents = 2
                        },
                        new SimpleCourse
                        {
                            id = Guid.NewGuid(),
                            name = "Course2",
                            countStudents=10,
                            countClasses=1
                        }
                    }
                },
                new ProfessorResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Professor2",
                    Data = new PersonalDataResponse(),
                    TeacherOfClasses = new List<SimpleClass>(),
                    TeacherOfCourses = new List<SimpleCourse>()
                }, 
                new ProfessorResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Professor3",
                    Data = new PersonalDataResponse(),
                    TeacherOfClasses = new List<SimpleClass>(),
                    TeacherOfCourses = new List<SimpleCourse>()
                }
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
            Assert.Equal(testProfessorList.First().Name, resultValue[0].Name);
            Assert.Equal(testProfessorList.First().Data.Id, resultValue[0].Data.Id);
            Assert.Equal(testProfessorList.First().TeacherOfCourses.Count, resultValue[0].TeacherOfCourses.Count);
            Assert.Equal(testProfessorList.First().TeacherOfCourses[0].id, resultValue[0].TeacherOfCourses[0].id);
            Assert.Equal(testProfessorList.First().TeacherOfClasses.Count, resultValue[0].TeacherOfClasses.Count);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Id, resultValue[0].TeacherOfClasses[0].Id);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Students.Count, resultValue[0].TeacherOfClasses[0].Students.Count);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Students[0].Id, resultValue[0].TeacherOfClasses[0].Students[0].Id);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Tests.Count, resultValue[0].TeacherOfClasses[0].Tests.Count);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Tests[0].ClassId, resultValue[0].TeacherOfClasses[0].Tests[0].ClassId);

        }
        [Fact]
        public async void CourseIdGet_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            Guid professorTestId = Guid.NewGuid();
            Guid classTestId = Guid.NewGuid();
            Guid guidForCourseTest = Guid.NewGuid();
            Guid guidClassTest = Guid.NewGuid();
            SimpleCourse courseTest = new SimpleCourse
            {
                id = guidForCourseTest,
                name = "Course1",
                countClasses = 2,
                countStudents = 2
            };
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
                    TeacherOfClasses = new List<SimpleClass>
                    {
                        new SimpleClass
                        {
                            Id = classTestId,
                            CourseId = guidForCourseTest,
                            ProfessorId =professorTestId,
                            Code = "12345",
                            Days = Api.Domain.Models.Enums.Days.TuTh,
                            Students = simpleStudentsTest,
                            Tests = simpleTestsTest
                        },
                        new SimpleClass
                        {
                            Id = Guid.NewGuid(),
                            CourseId = guidForCourseTest,
                            ProfessorId=professorTestId,
                            Code="67890",
                            Days = Api.Domain.Models.Enums.Days.MoWe,
                            Students = new List<SimpleStudent>(),
                            Tests = new List<SimpleTest>()
                        }
                    },
                    TeacherOfCourses = new List<SimpleCourse>
                    {
                        courseTest,
                        new SimpleCourse
                        {
                            id = Guid.NewGuid(),
                            name = "Course2",
                            countStudents=10,
                            countClasses=1
                        }
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
                },
                new ProfessorResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Professor3",
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
            Assert.Equal(testProfessorList.First().Name, resultValue[0].Name);
            Assert.Equal(testProfessorList.First().Data.Id, resultValue[0].Data.Id);
            Assert.Equal(testProfessorList.First().TeacherOfCourses.Count, resultValue[0].TeacherOfCourses.Count);
            Assert.Equal(testProfessorList.First().TeacherOfCourses[0].id, resultValue[0].TeacherOfCourses[0].id);
            Assert.Equal(testProfessorList.First().TeacherOfClasses.Count, resultValue[0].TeacherOfClasses.Count);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Id, resultValue[0].TeacherOfClasses[0].Id);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Students.Count, resultValue[0].TeacherOfClasses[0].Students.Count);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Students[0].Id, resultValue[0].TeacherOfClasses[0].Students[0].Id);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Tests.Count, resultValue[0].TeacherOfClasses[0].Tests.Count);
            Assert.Equal(testProfessorList.First().TeacherOfClasses[0].Tests[0].ClassId, resultValue[0].TeacherOfClasses[0].Tests[0].ClassId);
        }
        [Fact]
        public async void IdGet_Id_Is_Present_ReturnsOkResult()
        {
            //Arrange
            Guid professorTestId = Guid.NewGuid();
            Guid classTestId = Guid.NewGuid();
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
                TeacherOfClasses = new List<SimpleClass>
                    {
                        new SimpleClass
                        {
                            Id = classTestId,
                            CourseId = guidForCourseTest,
                            ProfessorId =professorTestId,
                            Code = "12345",
                            Days = Api.Domain.Models.Enums.Days.TuTh,
                            Students = simpleStudentsTest,
                            Tests = simpleTestsTest
                        },
                        new SimpleClass
                        {
                            Id = Guid.NewGuid(),
                            CourseId = guidForCourseTest,
                            ProfessorId=professorTestId,
                            Code="67890",
                            Days = Api.Domain.Models.Enums.Days.MoWe,
                            Students = new List<SimpleStudent>(),
                            Tests = new List<SimpleTest>()
                        }
                    },
                TeacherOfCourses = new List<SimpleCourse>
                    {
                        new SimpleCourse
                        {
                            id = guidForCourseTest,
                            name = "Course1",
                            countClasses = 2,
                            countStudents = 2
                        },
                        new SimpleCourse
                        {
                            id = Guid.NewGuid(),
                            name = "Course2",
                            countStudents=10,
                            countClasses=1
                        }
                    }
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
            Assert.Equal(profTest.Name, resultValue.Name);
            Assert.Equal(profTest.Data.Id, resultValue.Data.Id);
            Assert.Equal(profTest.TeacherOfCourses.Count, resultValue.TeacherOfCourses.Count);
            Assert.Equal(profTest.TeacherOfCourses[0].id, resultValue.TeacherOfCourses[0].id);
            Assert.Equal(profTest.TeacherOfClasses.Count, resultValue.TeacherOfClasses.Count);
            Assert.Equal(profTest.TeacherOfClasses[0].Id, resultValue.TeacherOfClasses[0].Id);
            Assert.Equal(profTest.TeacherOfClasses[0].Students.Count, resultValue.TeacherOfClasses[0].Students.Count);
            Assert.Equal(profTest.TeacherOfClasses[0].Students[0].Id, resultValue.TeacherOfClasses[0].Students[0].Id);
            Assert.Equal(profTest.TeacherOfClasses[0].Tests.Count, resultValue.TeacherOfClasses[0].Tests.Count);
            Assert.Equal(profTest.TeacherOfClasses[0].Tests[0].ClassId, resultValue.TeacherOfClasses[0].Tests[0].ClassId);
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
