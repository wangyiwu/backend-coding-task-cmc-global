using Application.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Porter.Controllers;

namespace WebAPI.Controllers;

[ApiController]
[Route("port")]
public class PortController : ControllerBase
{
    private readonly ILogger<PortController> _logger;
    private readonly IPortService _portService;

    public PortController(ILogger<PortController> logger,
        IPortService portService)
    {
        _logger = logger;
        _portService = portService ?? throw new ArgumentNullException(nameof(portService));
    }

    // Enable Any cors to help UI can callapi from localhost
    [HttpGet()]
    public async Task<IActionResult> GetPorts()
    {
        var result = await _portService.GetPorts();
        return Ok(result);
    }

}
