using CartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.RabbitMQClient
{
    public class MessageListenerFactory : IMessageListenerFactory
    {
        private readonly string _hostName;

        public MessageListenerFactory(string hostName)
        {
            _hostName = hostName;
        }

        public IMessageListener<T> CreateListener<T>(string queueName, Action<T> messageHandler)
        {
            return new MessageListener<T>(_hostName, queueName, messageHandler);
        }
    }
}
