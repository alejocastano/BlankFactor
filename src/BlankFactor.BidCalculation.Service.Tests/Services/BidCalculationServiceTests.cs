using BlankFactor.BidCalculation.Service.Entities;
using BlankFactor.BidCalculation.Service.Enums;
using BlankFactor.BidCalculation.Service.Services;

namespace BlankFactor.BidCalculation.Service.Tests.Services
{
    public class BidCalculationServiceTests
    {
        private readonly BidCalculationService _bidCalcualtionservice;

        public BidCalculationServiceTests()
        {
            _bidCalcualtionservice = new BidCalculationService();
        }

        [Theory]
        [InlineData(398.00, VehicleType.Common, 550.76)]
        [InlineData(501.00, VehicleType.Common, 671.02)]
        [InlineData(57.00, VehicleType.Common, 173.14)]
        [InlineData(1800.00, VehicleType.Luxury, 2167.00)]
        [InlineData(1100.00, VehicleType.Common, 1287.00)]
        [InlineData(1000000.00, VehicleType.Luxury, 1040320.00)]
        public void CalculateVehicleTotalPrice_WithDifferentScenarios_ShouldReturnExpectedTotal(decimal price, VehicleType type, decimal expectedTotal)
        {
            var vehicle = new Vehicle { Price = price, Type = type };
            var result = _bidCalcualtionservice.CalculateVehicleTotalPrice(vehicle);
            Assert.Equal(expectedTotal, result);
        }
    }
}