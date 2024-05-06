using CatalogService.Application.Items.GetItemById;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application.Items.GetAllItems
{
    internal sealed class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<ItemResponse>>
    {
        private readonly IRepository<Item> _itemRepository;

        public GetAllItemsQueryHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
    
        public async Task<List<ItemResponse>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetAll().Select((item, index) => new ItemResponse()
            {
                Id = item.Id,
                Name = item.Name,
                Image = item.Image,
                CategoryId = item.CategoryId,
                Price = item.Price,
                Amount = item.Amount,
            }).ToListAsync(cancellationToken);
        }
    }
}
