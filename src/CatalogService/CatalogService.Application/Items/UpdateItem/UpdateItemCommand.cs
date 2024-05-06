using MediatR;

namespace CatalogService.Application.Items.UpdateItem
{
    public sealed record UpdateItemCommand(Guid Id, string Name, string Description, string Image, Guid CategoryId, decimal Price, int Amount)
        : IRequest;
}
