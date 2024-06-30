using CartService.Domain;
using CartService.Persistence.Contexts;
using CartService.Domain.Repositories.Interfaces;

namespace CartService.Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ICartServiceContext _dbContext;

        public ItemRepository(ICartServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Item> GetItems(Guid cartId)
        {
            var cartCollection = _dbContext.Database.GetCollection<Cart>("carts");
            var cart = cartCollection.FindById(cartId);

            return cart?.Items;
        }

        public void AddItem(Guid cartId, Item item)
        {
            var cartCollection = _dbContext.Database.GetCollection<Cart>("carts");
            var cart = cartCollection.FindById(cartId);

            if (cart != null)
            {
                cart.Items ??= new List<Item>();
                cart.Items.Add(item);
                cartCollection.Update(cart);
            }
        }

        public void RemoveItem(Guid cartId, Guid itemId)
        {
            var cartCollection = _dbContext.Database.GetCollection<Cart>("carts");
            var cart = cartCollection.FindById(cartId);

            if (cart != null)
            {
                cart.Items?.RemoveAll(i => i.Id == itemId);
                cartCollection.Update(cart);
            }
        }

        public void UpdateItem(Item updatedItem)
        {
            var cartCollection = _dbContext.Database.GetCollection<Cart>("carts");
            var carts = cartCollection.FindAll();

            foreach (var cart in carts)
            {
                if (cart.Items != null)
                {
                    var item = cart.Items.FirstOrDefault(i => i.Id == updatedItem.Id);
                    if (item != null)
                    {
                        item.Name = updatedItem.Name;
                        item.Price = updatedItem.Price;

                        cartCollection.Update(cart);
                    }
                }
            }
        }
    }
}
