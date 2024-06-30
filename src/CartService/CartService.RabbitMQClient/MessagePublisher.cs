using CartService.Domain.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartService.RabbitMQClient
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IModel _channel;

        public MessagePublisher(string hostName, string queueName)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void Publish<T>(T message)
        {
            var messageString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageString);

            _channel.BasicPublish(exchange: "",
                                 routingKey: "queueName",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
