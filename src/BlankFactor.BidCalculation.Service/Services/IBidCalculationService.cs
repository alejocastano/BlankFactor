using BlankFactor.BidCalculation.Service.Entities;

namespace BlankFactor.BidCalculation.Service.Services
{
    public interface IBidCalculationService
    {
        decimal CalculateVehicleTotalPrice(Vehicle vehicle);
    }
}
