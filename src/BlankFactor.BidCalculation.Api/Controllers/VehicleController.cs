using BlankFactor.BidCalculation.Service.Entities;
using BlankFactor.BidCalculation.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlankFactor.BidCalculation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IBidCalculationService _bidCalculationService;

        public VehicleController(IBidCalculationService bidCalculationService)
        {
            _bidCalculationService = bidCalculationService;
        }
        /// <summary>
        /// Calculates the total price of a vehicle at a car auction.
        /// </summary>
        /// <param name="vehicle">The vehicle object containing price and the vehicle type information.</param>
        /// <remarks>
        /// Sample request for a common vehicle:
        ///
        ///     POST /CalculateTotalPrice
        ///     {
        ///        "price": 1000,
        ///        "type": "Common"
        ///     }
        ///     
        /// Sample request for a luxury vehicle:
        /// 
        ///     POST /CalculateTotalPrice
        ///     {
        ///        "price": 1000,
        ///        "type": "Luxury"
        ///     }      
        ///
        /// </remarks>
        /// <returns>The total price calculation result for the vehicle.</returns>
        /// <response code="200">Returns the total price of the vehicle</response>
        /// <response code="400">If the vehicle object is null or invalid</response>
        /// <response code="500">If an error occurs while processing your request</response>
        [HttpPost("CalculateTotalPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CalculateTotalPrice([FromBody] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                decimal totalPrice = _bidCalculationService.CalculateVehicleTotalPrice(vehicle);
                return Ok(totalPrice);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }

        }
    }
}
