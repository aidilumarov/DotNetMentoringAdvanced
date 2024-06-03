using CartService.Domain;
using CartService.Persistence.Contexts;
using CartService.Persistence.Repositories.Interfaces;

namespace CartService.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartServiceContext _dbContext;

        public CartRepository(ICartServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cart GetCart(Guid id)
        {
            var collection = _dbContext.Database.GetCollection<Cart>("carts");
            return collection.FindById(id);
        }

        public Cart AddCart(Cart cart)
        {
            var collection = _dbContext.Database.GetCollection<Cart>("carts");
            collection.Insert(cart);
            return cart;
        }

        public void UpdateCart(Cart cart)
        {
            var collection = _dbContext.Database.GetCollection<Cart>("carts");
            collection.Update(cart);
        }

        public void DeleteCart(Guid id)
        {
            var collection = _dbContext.Database.GetCollection<Cart>("carts");
            collection.Delete(id);
        }
    }
}
