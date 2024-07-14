using Microsoft.AspNetCore.Mvc;
using CartService.Application.Services;
using CartService.Domain;
using Asp.Versioning;
using CartService.API.SharedData;
using Microsoft.AspNetCore.Authorization;

namespace CartService.API.Controllers.Version1
{
    /// <summary>
    /// Manages the operations related to carts.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.Buyer)]
    public class CartController : ControllerBase
    {
        private readonly Application.Services.CartService _cartService;
        private readonly ItemService _itemService;

        public CartController(Application.Services.CartService cartService, ItemService itemService)
        {
            _cartService = cartService;
            _itemService = itemService;
        }

        /// <summary>
        /// Gets the cart with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the cart.</param>
        /// <returns>The cart with the specified ID.</returns>
        [HttpGet("{id}")]
        public IActionResult GetCart(Guid id)
        {
            var cart = _cartService.GetCart(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        /// <summary>
        /// Adds an item to the cart with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the cart.</param>
        /// <param name="item">The item to add to the cart.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpPost("{id}")]
        public IActionResult AddItem(Guid id, [FromBody] Item item)
        {
            var cart = _cartService.GetCart(id);
            if (cart == null)
            {
                cart = _cartService.AddCart(new Cart { Id = id });
            }
            _itemService.AddItem(id, item);
            return Ok();
        }

        /// <summary>
        /// Deletes an item from the cart with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the cart.</param>
        /// <param name="itemId">The ID of the item to delete.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpDelete("{id}/{itemId}")]
        public IActionResult DeleteItem(Guid id, Guid itemId)
        {
            var cart = _cartService.GetCart(id);
            if (cart == null)
            {
                return NotFound();
            }
            _itemService.RemoveItem(id, itemId);
            return Ok();
        }
    }
}