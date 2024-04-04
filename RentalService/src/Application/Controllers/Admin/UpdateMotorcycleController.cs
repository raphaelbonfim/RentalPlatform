using Application.DTOs.Admin;
using Application.Services.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/motorcycle")]
    public class UpdateMotorcycleController : ControllerBase
    {
        private readonly IUpdateMotorcycleCommandService _commandService;

        public UpdateMotorcycleController(IUpdateMotorcycleCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<IActionResult> UpdateMotorcycle(InUpdateMotorcycleDTO dto, CancellationToken cancellationToken)
        {
            await _commandService.ProcessAsync(dto, cancellationToken);
            return Ok();
        }
    }
}
