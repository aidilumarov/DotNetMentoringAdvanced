using CartService.Domain;

namespace CartService.Persistence.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCart(Guid id);
        Cart AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Guid id);
    }
}