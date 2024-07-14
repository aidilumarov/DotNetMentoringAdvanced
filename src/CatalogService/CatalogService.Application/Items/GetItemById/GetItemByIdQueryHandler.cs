using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.GetItemById
{
    public sealed class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemResponse?>
    {
        private IRepository<Item> _itemRepository;
        public GetItemByIdQueryHandler(IRepository<Item> itemRepository) 
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemResponse?> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var itemToReturn = await _itemRepository.GetByIdAsync(request.Id);

            if (itemToReturn != null)
            {
                return new ItemResponse()
                {
                    Id = itemToReturn.Id,
                    Name = itemToReturn.Name,
                    Image = itemToReturn.Image,
                    CategoryId = itemToReturn.CategoryId,
                    Price = itemToReturn.Price,
                    Amount = itemToReturn.Amount
                };
            }

            return null;
        }
    }
}
