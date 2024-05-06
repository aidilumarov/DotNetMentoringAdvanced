using CatalogService.Application.Items.GetItemById;
using MediatR;

namespace CatalogService.Application.Items.GetAllItems
{
    public sealed record GetAllItemsQuery() 
        : IRequest<List<ItemResponse>>;
}
