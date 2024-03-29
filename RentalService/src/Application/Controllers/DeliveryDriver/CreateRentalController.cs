using Application.DTOs.DeliveryDriver;
using Application.Services.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.DeliveryDriver
{
    [ApiController]
    [Route("api/v1/rental")]
    public class CreateRentalController : ControllerBase
    {
        private readonly ICreateRentalCommandService _commandService;

        public CreateRentalController(ICreateRentalCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OutCreateRentalDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateRental(InCreateRentalDTO dto, CancellationToken cancellationToken)
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
