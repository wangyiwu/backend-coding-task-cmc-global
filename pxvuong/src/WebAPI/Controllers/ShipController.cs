using Application.Models.RequestModel.Ship;
using Application.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Porter.Controllers
{
    [ApiController]
    [Route("ship")]
    public class ShipController : ControllerBase
    {

        private readonly ILogger<ShipController> _logger;
        private readonly IShipService _shipService;

        public ShipController(ILogger<ShipController> logger,
            IShipService shipService)
        {
            _logger = logger;
            _shipService = shipService ?? throw new ArgumentNullException(nameof(shipService));
        }

        [HttpGet()]
        public async Task<IActionResult> GetShips()
        {
            var result = await _shipService.GetShips();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShip(CreateShipRequest request)
        {
            var result = await _shipService.CreateShip(request);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateVelocity(string id, UpdateVelocityRequest request)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var result = await _shipService.UpdateVelocity(id, request);
            return Ok(result);
        }

        [HttpGet("closest-port/{name}")]
        public async Task<IActionResult> ClosestPort(string name)
        {
            var result = await _shipService.ClosestPort(name);
            return Ok(result);
        }

    }
}