using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Porter.Controllers
{
    [ApiController]
    [Route("[controller]")]
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


        [HttpGet("get-ships")]
        public async Task<IActionResult> GetShips()
        {
            var result = await _shipService.GetShips();
            return Ok(result);
        }


    }
}