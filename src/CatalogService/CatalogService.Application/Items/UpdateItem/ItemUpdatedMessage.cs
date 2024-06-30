namespace CatalogService.Application.Items.UpdateItem
{
    public sealed record ItemUpdatedMessage(Guid Id, string Name, decimal Price);
}
