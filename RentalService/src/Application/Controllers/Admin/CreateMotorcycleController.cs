using Application.DTOs.Admin;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/motorcycle")]
    public class CreateMotorcycleController : ControllerBase
    {
        private readonly ICreateMotorcycleCommandService _commandService;

        public CreateMotorcycleController(ICreateMotorcycleCommandService commandService)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        }

        [HttpPost]
        [ProducesResponseType(typeof(OutCreateMotorcycleDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMotorcycle(InCreateMotorcycleDTO dto, CancellationToken cancellationToken)
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
