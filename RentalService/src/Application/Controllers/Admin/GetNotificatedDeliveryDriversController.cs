using Application.Services.Queries.interfaces;
using Common.Application;
using Domain.DAO.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/delivery_driver/notifications")]
    public class GetNotificatedDeliveryDriversController : ControllerBase
    {
        private readonly IGetNotificatedDeliveryDriversQueryService _service;

        public GetNotificatedDeliveryDriversController(IGetNotificatedDeliveryDriversQueryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("notifications/{orderId}")]
        [ProducesResponseType(typeof(ICollection<OutNotificatedDeliveryDriverQueryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNotificatedDeliveryDrivers(Guid orderId, CancellationToken cancellationToken)
        {
            return Ok(await _service.ProcessAsync(orderId, cancellationToken));
        }
    }
}
