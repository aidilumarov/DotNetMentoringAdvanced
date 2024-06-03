using CartService.Domain;

namespace CartService.Persistence.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCart(int id);
        Cart AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(int id);
    }
}