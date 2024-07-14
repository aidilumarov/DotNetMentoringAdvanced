using CatalogService.API.SharedData;
using CatalogService.Application.Items.CreateItem;
using CatalogService.Application.Items.DeleteItem;
using CatalogService.Application.Items.GetAllItems;
using CatalogService.Application.Items.GetItemById;
using CatalogService.Application.Items.GetItemPropertiesById;
using CatalogService.Application.Items.UpdateItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Manager + "," + UserRoles.Buyer)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _mediator.Send(new GetAllItemsQuery());
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Manager + "," + UserRoles.Buyer)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _mediator.Send(new GetItemByIdQuery(id));
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet("{id}/properties")]
        [Authorize(Roles = UserRoles.Manager + "," + UserRoles.Buyer)]
        public async Task<IActionResult> GetPropertiesById(Guid id)
        {
            var propertyResponse = await _mediator.Send(new GetItemPropertiesByIdQuery(id));
            if (propertyResponse == null)
            {
                return NotFound();
            }

            return Ok(propertyResponse.Properties);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Manager)]
        public async Task<IActionResult> Create(CreateItemCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Manager)]
        public async Task<IActionResult> Update(Guid id, UpdateItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Manager)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteItemCommand(id));
            return NoContent();
        }
    }
}