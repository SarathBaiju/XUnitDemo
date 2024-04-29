using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;
using XUnitDemo.Controllers;
using XUnitDemo.Repository;

namespace XUnitTest
{
    public class PeopleControllerTest
    {
        private readonly Mock<IPeopleRepository> _peopleRepositoryMock;
        private readonly PeopleController _peopleController;

        public PeopleControllerTest()
        {
            _peopleRepositoryMock = new Mock<IPeopleRepository>();
            _peopleController = new PeopleController(_peopleRepositoryMock.Object);
        }

        [Fact]
        public void Get_NotFound()
        {
            ///Arrange
            _peopleRepositoryMock.Setup(m => m.GetAll()).Returns(Enumerable.Empty<PeopleData>());

            ///Act
            var result = _peopleController.Get() as NotFoundResult;

            ///Assert
            Assert.NotNull(result);
            Assert.Equivalent(result.StatusCode, 404);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_Success()
        {
            ///Arrange
            _peopleRepositoryMock.Setup(m => m.GetAll()).Returns(new List<PeopleData>() { new PeopleData()});

            ///Act
            var result = _peopleController.Get() as OkObjectResult;

            ///Assert
            Assert.NotNull(result);
            Assert.Equivalent(result.StatusCode, 200);
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        public void IsOdd_Success(int number)
        {
            Assert.False(IsOdd(number));
        }

        public bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}