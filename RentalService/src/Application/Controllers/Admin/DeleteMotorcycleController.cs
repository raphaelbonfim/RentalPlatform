using Application.DTOs.Admin;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/motorcycle")]
    public class DeleteMotorcycleController : ControllerBase
    {
        private readonly IDeleteMotorcycleCommandService _commandService;

        public DeleteMotorcycleController(IDeleteMotorcycleCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<IActionResult> DeleteMotorcycle(InDeleteMotorcycleDTO dto, CancellationToken cancellationToken)
        {            
                await _commandService.ProcessAsync(dto, cancellationToken);
                return Ok();         
        }
    }
}
