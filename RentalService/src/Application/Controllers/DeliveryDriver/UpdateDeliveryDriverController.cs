using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/delivery_driver")]
    public class UpdateDeliveryDriverController : ControllerBase
    {
        private readonly IUpdateDeliveryDriverCommandService _commandService;

        public UpdateDeliveryDriverController(IUpdateDeliveryDriverCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task UpdateDeliveryDriver(InUpdateDeliveryDriverDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                await _commandService.ProcessAsync(dto, cancellationToken);
                Ok();
            }
            catch (BusinessException ex)
            {
                BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                StatusCode(500, ex.Message);
            }
        }
    }
}
