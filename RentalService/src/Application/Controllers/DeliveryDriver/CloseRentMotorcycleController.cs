using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/motorcycle/rent/close")]
    public class CloseRentMotorcycleController : ControllerBase
    {
        private readonly ICloseRentMotorcycleCommandService _commandService;

        public CloseRentMotorcycleController(ICloseRentMotorcycleCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OutCloseRentMotorcycleDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CloseRentMotorcycle(InCloseRentMotorcycleDTO dto, CancellationToken cancellationToken)
        {
            return Ok(await _commandService.ProcessAsync(dto, cancellationToken));
        }
    }
}
