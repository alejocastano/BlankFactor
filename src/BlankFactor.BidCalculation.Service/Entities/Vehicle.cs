using BlankFactor.BidCalculation.Service.Enums;

namespace BlankFactor.BidCalculation.Service.Entities
{
    public class Vehicle
    {
        public decimal Price { get; set; }
        public VehicleType Type { get; set; }
    }
}
