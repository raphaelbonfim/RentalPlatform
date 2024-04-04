using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/delivery_driver/cnh")]
    public class UpdateDeliveryDriverController : ControllerBase
    {
        private readonly IUpdateDeliveryDriverCommandService _commandService;

        public UpdateDeliveryDriverController(IUpdateDeliveryDriverCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDeliveryDriver(InUpdateDeliveryDriverDTO dto, CancellationToken cancellationToken)
        {
            await _commandService.ProcessAsync(dto, cancellationToken);
            return Ok();
        }
    }
}
