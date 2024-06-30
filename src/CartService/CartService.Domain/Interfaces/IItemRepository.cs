using CartService.Domain;

namespace CartService.Domain.Repositories.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItems(Guid cartId);
        void AddItem(Guid cartId, Item item);
        void RemoveItem(Guid cartId, Guid itemId);
        void UpdateItem(Item item);
    }
}
