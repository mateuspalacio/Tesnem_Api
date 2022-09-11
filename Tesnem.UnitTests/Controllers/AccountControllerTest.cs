using Tesnem.Api.Domain.Services;
using Tesnem.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO;
using System.Net;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Repository;
using AutoMapper;
using Tesnem.Api.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Tesnem.Api.Domain.Mapper;
using Tesnem.Api.Domain.Exceptions;

namespace Tesnem.UnitTests.Controllers
{
    public class AccountControllerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly AccountController _accountController;

        public AccountControllerTest()
        {
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
            var store = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            _userManagerMock.Object.UserValidators.Add(new UserValidator<User>());
            _userManagerMock.Object.PasswordValidators.Add(new PasswordValidator<User>());
            _accountController = new AccountController(_mapper,_userManagerMock.Object);
            UserRegistration userTest = new UserRegistration
            {
                PersonId = Guid.NewGuid(),
                Password = "12345",
                ConfirmPassword = "12345",
                UserName = "Pedro"
            };
            User mappedUser = _mapper.Map<User>(userTest);
            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(x => x.CreateAsync(It.Is<User>(u => u.UserName == "PedroErrado"))).ReturnsAsync(IdentityResult.Failed());
            _userManagerMock.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(mappedUser);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(mappedUser, userTest.Password)).ReturnsAsync(true);
            _userManagerMock.Setup(x => x.CreateAsync(It.Is<User>(u => u.UserName == "PedroErrado"))).ReturnsAsync(IdentityResult.Failed());
        }
        [Fact]
        public async void RegisterStudent_GoodRequest_ReturnsOk()
        {
            //Arrange
            UserRegistration userTest = new UserRegistration
            {
                PersonId = Guid.NewGuid(),
                Password = "12345",
                ConfirmPassword = "12345",
                UserName = "Pedro"
            };

            //Act
            var functionResult = await _accountController.RegisterStudent(userTest);

            //Assert
            var okResult = Assert.IsType<NoContentResult>(functionResult);
            Assert.Equal((int)HttpStatusCode.NoContent, (int)okResult.StatusCode);
        }
        [Fact]
        public async void RegisterStudent_BadRequest_ReturnsError()
        {
            //Arrange
            UserRegistration userTest = new UserRegistration
            {
                PersonId = Guid.NewGuid(),
                Password = "12345",
                ConfirmPassword = "12345",
                UserName = "PedroErrado"
            };

            //Act
            var functionResult = await _accountController.RegisterStudent(userTest);

            //Assert
            var okResult = Assert.ThrowsAsync<ErrorException>(() => _accountController.RegisterAdmin(userTest)); ;
        }
        [Fact]
        public async void RegisterProfessor_GoodRequest_ReturnsOk()
        {
            //Arrange
            UserRegistration userTest = new UserRegistration
            {
                PersonId = Guid.NewGuid(),
                Password = "12345",
                ConfirmPassword = "12345",
                UserName = "Pedro"
            };

            //Act
            var functionResult = await _accountController.RegisterProfessor(userTest);

            //Assert
            var okResult = Assert.IsType<NoContentResult>(functionResult);
            Assert.Equal((int)HttpStatusCode.NoContent, (int)okResult.StatusCode);
        }
        [Fact]
        public async void RegisterProfessor_BadRequest_ReturnsError()
        {
            //Arrange
            UserRegistration userTest = new UserRegistration
            {
                PersonId = Guid.NewGuid(),
                Password = "12345",
                ConfirmPassword = "12345",
                UserName = "PedroErrado"
            };

            //Act
            var functionResult = await _accountController.RegisterProfessor(userTest);

            //Assert
            var okResult = Assert.ThrowsAsync<ErrorException>(() => _accountController.RegisterAdmin(userTest)); ;
        }
        [Fact]
        public async void RegisterAdmin_GoodRequest_ReturnsOk()
        {
            //Arrange
            UserRegistration userTest = new UserRegistration
            {
                PersonId = Guid.NewGuid(),
                Password = "12345",
                ConfirmPassword = "12345",
                UserName = "Pedro"
            };

            //Act
            var functionResult = await _accountController.RegisterAdmin(userTest);

            //Assert
            var okResult = Assert.IsType<NoContentResult>(functionResult);
            Assert.Equal((int)HttpStatusCode.NoContent, (int)okResult.StatusCode);
        }
        [Fact]
        public async void RegisterAdmin_BadRequest_ReturnsError()
        {
            //Arrange
            UserRegistration userTest = new UserRegistration
            {
                PersonId = Guid.NewGuid(),
                Password = "12345",
                ConfirmPassword = "12345",
                UserName = "PedroErrado"
            };

            //Act
            var functionResult = await _accountController.RegisterAdmin(userTest);

            //Assert
            var okResult = Assert.ThrowsAsync<ErrorException>(() => _accountController.RegisterAdmin(userTest));;
        }
        /*[Fact]
        public async void LoginAdmin_GoodRequest_ReturnsOk()
        {
            //Arrange
            UserLogin userTest = new UserLogin
            {
                Password = "12345",
                UserName = "Pedro",
            };

            //Act
            var functionResult = await _accountController.AdminLogin(userTest);

            //Assert
            var okResult = Assert.IsType<NoContentResult>(functionResult);
            Assert.Equal((int)HttpStatusCode.NoContent, (int)okResult.StatusCode);
        }*/
    }
}
