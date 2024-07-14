using CatalogService.Application.Items.UpdateItem;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.GetItemPropertiesById
{
    public sealed class GetItemPropertiesByIdHandler : IRequestHandler<GetItemPropertiesByIdQuery, ItemPropertyResponse>
    {
        private IRepository<Item> _itemRepository;

        public GetItemPropertiesByIdHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemPropertyResponse?> Handle(GetItemPropertiesByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetAll()
                .Where(x => x.Id == request.Id)
                .Include(x => x.Properties)
                .SingleOrDefaultAsync(cancellationToken);

            if (item == null) { return null; }

            return new ItemPropertyResponse()
            {
                Properties = item.Properties.ToDictionary(x => x.PropertyName, x => x.PropertyValue)
            };
        }
    }
}
