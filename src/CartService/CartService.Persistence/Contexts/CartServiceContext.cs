using LiteDB;
using Microsoft.Extensions.Options;

namespace CartService.Persistence.Contexts
{
    public class CartServiceContext : ICartServiceContext
    {
        public ILiteDatabase Database { get; }

        public CartServiceContext(IOptions<CartServiceDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.ConnectionString);
        }
    }
}
