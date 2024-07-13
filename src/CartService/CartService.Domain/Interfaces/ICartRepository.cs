using CartService.Domain;

namespace CartService.Domain.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCart(Guid id);
        Cart AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Guid id);
    }
}