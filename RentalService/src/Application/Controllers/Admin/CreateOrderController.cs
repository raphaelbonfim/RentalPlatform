using Application.DTOs.Admin;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/order")]
    public class CreateOrderController : Controller
    {
        private readonly ICreateOrderCommandService _commandService;

        public CreateOrderController(ICreateOrderCommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OutCreateOrderDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrder(InCreateOrderDTO dto, CancellationToken cancellationToken)
        {           
                return Ok(await _commandService.ProcessAsync(dto, cancellationToken));        
        }
    }
}
