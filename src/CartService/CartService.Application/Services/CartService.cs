using CartService.Domain;
using CartService.Domain.Repositories.Interfaces;

namespace CartService.Application.Services
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCart(Guid id)
        {
            return _cartRepository.GetCart(id);
        }

        public Cart AddCart(Cart cart)
        {
            return _cartRepository.AddCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        }

        public void DeleteCart(Guid id)
        {
            _cartRepository.DeleteCart(id);
        }
    }
}
