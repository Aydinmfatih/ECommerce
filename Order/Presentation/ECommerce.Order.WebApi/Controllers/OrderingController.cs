using ECommerce.Order.Application.Features.CQRS.Handlers;
using ECommerce.Order.Application.Features.Mediator.Commands;
using ECommerce.Order.Application.Features.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {

            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingComment command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş Oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingComment command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdering(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int  id)
        {
            await _mediator.Send(new RemoveOrderingComment(id));
            return Ok("Sipariş Silindi");
        }
    }
}
