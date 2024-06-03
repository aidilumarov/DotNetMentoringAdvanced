using MediatR;

namespace CatalogService.Application.Items.CreateItem
{
    public sealed record CreateItemCommand(string Name, string Description, string Image, Guid CategoryId, decimal Price, int Amount) 
        : IRequest<Guid>;
}
