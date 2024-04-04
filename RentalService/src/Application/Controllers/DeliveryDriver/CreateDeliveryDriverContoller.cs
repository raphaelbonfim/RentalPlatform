using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/delivery_driver")]
    public class CreateDeliveryDriverContoller : ControllerBase
    {
        private readonly ICreateDeliveryDriverCommandService _commandService;

        public CreateDeliveryDriverContoller(ICreateDeliveryDriverCommandService commandService)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        }

        [HttpPost]
        [ProducesResponseType(typeof(OutCreateDeliveryDriverDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDeliveryDriver(InCreateDeliveryDriverDTO dto, CancellationToken cancellationToken)
        {
            return Ok(await _commandService.ProcessAsync(dto, cancellationToken));
        }
    }
}
