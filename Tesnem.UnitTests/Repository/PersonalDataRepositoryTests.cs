using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.UnitTests.Repository
{
    public class PersonalDataRepositoryTests
    {
        private Mock<IPersonalDataRepository> _rep = new Mock<IPersonalDataRepository>();

        [Fact]
        public async Task Should_Add_PersonalData()
        {
            // Arrange
            var personalData = new Mock<PersonalData>();
            _rep.Setup(x => x.Add(It.IsAny<PersonalData>())).Returns(Task.FromResult(personalData.Object));

            // Act
            var resp = await _rep.Object.Add(personalData.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(personalData.Object, resp);
        }

        [Fact]
        public async Task Should_Get_PersonalData()
        {
            // Arrange
            var personalData = new Mock<PersonalData>();
            _rep.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(personalData.Object));

            // Act
            var resp = await _rep.Object.GetById(personalData.Object.Id);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(personalData.Object, resp);
        }
        
        [Fact]
        public void Should_Remove_PersonalDatas()
        {
            // Arrange
            var personalData = new Mock<PersonalData>();
            _rep.Setup(x => x.Delete(It.IsAny<PersonalData>())).Returns(Task.FromResult(personalData.Object));

            // Act
            var resp = _rep.Object.Delete(personalData.Object).IsCompletedSuccessfully;

            // Assert
            Assert.True(resp);
        }

        [Fact]
        public async Task Should_Update_PersonalData()
        {
            // Arrange
            var personalData = new Mock<PersonalData>();
            _rep.Setup(x => x.Update(It.IsAny<PersonalData>())).Returns(Task.FromResult(personalData.Object));

            // Act
            var resp = await _rep.Object.Update(personalData.Object);

            // Assert
            Assert.NotNull(resp);
            Assert.Equal(personalData.Object, resp);
        }
    }
}
