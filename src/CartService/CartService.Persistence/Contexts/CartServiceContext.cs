using LiteDB;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace CartService.Persistence.Contexts
{
    public class CartServiceContext : ICartServiceContext
    {
        public ILiteDatabase Database { get; }

        public CartServiceContext(IOptions<CartServiceDbOptions> options)
        {
            Database = new LiteDatabase(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, options.Value.ConnectionString));
        }
    }
}
