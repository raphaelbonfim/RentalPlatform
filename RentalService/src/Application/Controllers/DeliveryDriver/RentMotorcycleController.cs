using Application.DTOs.DeliveryDriver;
using Application.Services.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/rent_motorcycle")]
    public class RentMotorcycleController : ControllerBase
    {

        private readonly IRentMotorcycleCommandService _commandService;

        public RentMotorcycleController(IRentMotorcycleCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OutRentMotorcycleDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RentMotorcycle(InRentMotorcycleDTO dto, CancellationToken cancellationToken)
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
