using CatalogService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.RabbitMQClient
{
    public class MessagePublisherFactory : IMessagePublisherFactory
    {
        private readonly string _hostName;
        private readonly Dictionary<string, IMessagePublisher> _publishers;

        public MessagePublisherFactory(string hostName)
        {
            _hostName = hostName;
            _publishers = new Dictionary<string, IMessagePublisher>();
        }

        public IMessagePublisher CreatePublisher(string queueName)
        {
            if (!_publishers.TryGetValue(queueName, out var publisher))
            {
                publisher = new MessagePublisher(_hostName, queueName);
                _publishers[queueName] = publisher;
            }

            return publisher;
        }
    }
}
