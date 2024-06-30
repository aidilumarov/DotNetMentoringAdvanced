using CatalogService.Application.Items.CreateItem;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

namespace CatalogService.Application.Items.UpdateItem
{
    internal sealed class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMessagePublisherFactory _messagePublisherFactory;
        private readonly string _itemUpdatedQueueName;

        public UpdateItemCommandHandler(IRepository<Item> itemRepository, IMessagePublisherFactory messagePublisherFactory, IConfiguration configuration)
        {
            _itemRepository = itemRepository;
            _messagePublisherFactory = messagePublisherFactory;
            _itemUpdatedQueueName = configuration.GetSection("MessageQueue:Queues:ItemUpdated").Value;
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

                SendUpdateItemMessage(itemToUpdate);
            }
        }

        private void SendUpdateItemMessage(Item updatedItem)
        {
            var updateItemMessagePublisher = _messagePublisherFactory.CreatePublisher(_itemUpdatedQueueName);
            var itemUpdatedMessage = new ItemUpdatedMessage(updatedItem.Id, updatedItem.Name, updatedItem.Price);

            updateItemMessagePublisher.Publish(itemUpdatedMessage);
        }
    }
}
