using Application.DTOs.Admin;
using Application.Services.Interfaces;
using Common.Application;
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

        public async Task UpdateMotorcycle(InUpdateMotorcycleDTO dto, CancellationToken cancellationToken)
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
