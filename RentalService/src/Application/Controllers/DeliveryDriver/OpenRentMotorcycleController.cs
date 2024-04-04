using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/motorcycle/rent/open")]
    public class OpenRentMotorcycleController : ControllerBase
    {

        private readonly IOpenRentMotorcycleCommandService _commandService;

        public OpenRentMotorcycleController(IOpenRentMotorcycleCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OutOpenRentMotorcycleDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OpenRentMotorcycle(InOpenRentMotorcycleDTO dto, CancellationToken cancellationToken)
        {
            return Ok(await _commandService.ProcessAsync(dto, cancellationToken));
        }
    }
}
