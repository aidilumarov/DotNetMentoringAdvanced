using CartService.Domain;
using CartService.Persistence.Repositories;

namespace CartService.Application
{
    internal class ItemService
    {
        private readonly ItemRepository _itemRepository;

        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<Item> GetItems(int cartId)
        {
            return _itemRepository.GetItems(cartId);
        }

        public void AddItem(int cartId, Item item)
        {
            _itemRepository.AddItem(cartId, item);
        }

        public void RemoveItem(int cartId, int itemId)
        {
            _itemRepository.RemoveItem(cartId, itemId);
        }
    }
}
