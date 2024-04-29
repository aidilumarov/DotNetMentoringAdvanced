using LiteDB;

namespace CartService.Persistence.Contexts
{
    public interface ICartServiceContext
    {
        ILiteDatabase Database { get; }
    }
}
