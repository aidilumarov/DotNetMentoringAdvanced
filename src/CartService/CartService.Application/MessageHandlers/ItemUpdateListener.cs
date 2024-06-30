using CartService.Application.MessageHandlers.Messages;
using CartService.Domain;
using CartService.Domain.Interfaces;
using CartService.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.MessageHandlers
{
    public class ItemUpdateListener : BackgroundService
    {
        private readonly IMessageListener<ItemUpdatedMessage> _messageListener;
        private readonly IItemRepository _itemRepository;

        public ItemUpdateListener(
            IMessageListenerFactory messageListenerFactory, 
            IItemRepository itemRepository, 
            IConfiguration configuration)
        {
            var itemUpdatedQueueName = configuration.GetSection("MessageQueue:Queues:ItemUpdated").Value;
            _messageListener = messageListenerFactory.CreateListener<ItemUpdatedMessage>(itemUpdatedQueueName, HandleItemUpdatedMessage);
            _itemRepository = itemRepository;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        private void HandleItemUpdatedMessage(ItemUpdatedMessage message)
        {
            var itemToUpdate = new Item()
            {
                Id = message.Id,
                Name = message.Name,
                Price = message.Price
            };

            _itemRepository.UpdateItem(itemToUpdate);
        }
    }
}
