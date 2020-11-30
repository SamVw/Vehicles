using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Vehicles.Controllers;
using Vehicles.Models;
using Vehicles.Services;

namespace Vehicles.UnitTests
{
    [TestClass]
    public class HomeControllerTests
    {

        [TestMethod]
        public void Delete_GivenNonExistingId_ReturnsNotFoundResultInstance()
        {
            // Arrange
            var mock = new Mock<IVehicleRepository>();
            mock.Setup(repo => repo.Delete(It.IsAny<Vehicle>())).Throws<ArgumentException>();

            var sut = new HomeController(mock.Object);

            // Act
            var result = sut.Delete(-9999);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
