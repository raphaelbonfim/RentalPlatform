using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/close_rent_motorcycle")]
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
             try
            {
                return Ok(await _commandService.ProcessAsync(dto, cancellationToken));
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
