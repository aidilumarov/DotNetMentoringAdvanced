using MediatR;


namespace CatalogService.Application.Items.GetItemById
{
    public sealed record GetItemByIdQuery(Guid Id) 
        : IRequest<ItemResponse>;
}
