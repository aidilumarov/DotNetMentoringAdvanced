using CatalogService.Application.Items.CreateItem;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

namespace CatalogService.Application.Items.UpdateItem
{
    internal sealed class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IRepository<Item> _itemRepository;
        public UpdateItemCommandHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _itemRepository.GetByIdAsync(request.Id);

            if (itemToUpdate != null)
            {
                _itemRepository.Update(itemToUpdate);

                itemToUpdate.Name = request.Name;
                itemToUpdate.Image = request.Image;
                itemToUpdate.CategoryId = request.CategoryId;
                itemToUpdate.Price = request.Price;
                itemToUpdate.Amount = request.Amount;
                
                await _itemRepository.SaveAsync();
            }
        }
    }
}
