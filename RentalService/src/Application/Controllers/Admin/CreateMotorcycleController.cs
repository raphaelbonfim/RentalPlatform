using Application.DTOs.Admin;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/motorcycle")]
    public class CreateMotorcycleController : ControllerBase
    {
        private readonly ICreateMotorCycleCommandService _commandService;

        public CreateMotorcycleController(ICreateMotorCycleCommandService commandService)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);               
            }            
        }
    }
}
