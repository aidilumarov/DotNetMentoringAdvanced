using CartService.Domain;

namespace CartService.Persistence.Repositories.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItems(Guid cartId);
        void AddItem(Guid cartId, Item item);
        void RemoveItem(Guid cartId, int itemId);
    }
}
