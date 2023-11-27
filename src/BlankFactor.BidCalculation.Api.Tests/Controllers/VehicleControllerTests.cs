using BlankFactor.BidCalculation.Api.Controllers;
using BlankFactor.BidCalculation.Service.Entities;
using BlankFactor.BidCalculation.Service.Enums;
using BlankFactor.BidCalculation.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BlankFactor.BidCalculation.Api.Tests.Controllers
{
    public class VehicleControllerTests
    {
        private readonly Mock<IBidCalculationService> _mockService;
        private readonly VehicleController _controller;

        public VehicleControllerTests()
        {
            _mockService = new Mock<IBidCalculationService>();
            _controller = new VehicleController(_mockService.Object);
        }

        [Fact]
        public void CalculateTotalPrice_ValidVehicle_ReturnsOkResultWithTotalPrice()
        {
            var vehicle = new Vehicle { Price = 1000m, Type = VehicleType.Common };
            _mockService.Setup(s => s.CalculateVehicleTotalPrice(It.IsAny<Vehicle>())).Returns(1100m);

            var result = _controller.CalculateTotalPrice(vehicle);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1100m, okResult.Value);
        }

        [Fact]
        public void CalculateTotalPrice_InvalidModel_ReturnsBadRequest()
        {
            _controller.ModelState.AddModelError("error", "there was an error");

            var result = _controller.CalculateTotalPrice(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
