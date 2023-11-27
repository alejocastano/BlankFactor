using BlankFactor.BidCalculation.Service.Entities;
using BlankFactor.BidCalculation.Service.Enums;

namespace BlankFactor.BidCalculation.Service.Services
{
    public class BidCalculationService : IBidCalculationService
    {
        public decimal CalculateVehicleTotalPrice(Vehicle vehicle)
        {
            decimal storageFee = 100;
            decimal basicUserFee = CalculateBasicUserFee(vehicle.Price, vehicle.Type);
            decimal sellerSpecialFee = CalculateSellerSpecialFee(vehicle.Price, vehicle.Type);
            decimal addedCost = CalculateAddedCost(vehicle.Price);
            return vehicle.Price + basicUserFee + sellerSpecialFee + addedCost + storageFee;
        }

        private decimal CalculateBasicUserFee(decimal price, VehicleType type)
        {
            decimal min = type == VehicleType.Common ? 10 : 25;
            decimal max = type == VehicleType.Common ? 50 : 200;
            decimal basicUserFee = price * 0.10m;
            return Math.Clamp(basicUserFee, min, max);
        }

        private decimal CalculateSellerSpecialFee(decimal price, VehicleType type)
        {
            return price * (type == VehicleType.Common ? 0.02m : 0.04m);
        }
        private decimal CalculateAddedCost(decimal price)
        {
            return price switch
            {
                > 3000 => 20,
                > 1000 => 15,
                > 500 => 10,
                >= 1 => 5,
                _ => 0,
            };
        }
    }
}


