using CartService.Domain;

namespace CartService.Persistence.Repositories.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItems(int cartId);
        void AddItem(int cartId, Item item);
        void RemoveItem(int cartId, int itemId);
    }
}
