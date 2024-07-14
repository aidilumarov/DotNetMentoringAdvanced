using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.DeleteItem
{
    public sealed class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IRepository<Item> _itemRepository;

        public DeleteItemCommandHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
    
        public async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _itemRepository.GetByIdAsync(request.Id);
            
            if (itemToDelete != null)
            {
                _itemRepository.Delete(itemToDelete);
                await _itemRepository.SaveAsync();
            }
        }
    }
}
