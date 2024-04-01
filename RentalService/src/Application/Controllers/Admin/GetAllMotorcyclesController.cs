using Application.Services.Queries.interfaces;
using Common.Application;
using Domain.DAO.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/motorcycle")]
    public class GetAllMotorcyclesController : ControllerBase
    {
        private readonly IGetAllMotorcyclesQueryService _queryService;

        public GetAllMotorcyclesController(IGetAllMotorcyclesQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        [Route("{plate?}")]
        [ProducesResponseType(typeof(ICollection<OutMotorcycleQueryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMotorcycles(string? plate, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _queryService.ProcessAsync(plate, cancellationToken));
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
