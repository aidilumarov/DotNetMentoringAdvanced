using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Interfaces
{
    public interface IMessagePublisherFactory
    {
        IMessagePublisher CreatePublisher(string queueName);
    }
}
