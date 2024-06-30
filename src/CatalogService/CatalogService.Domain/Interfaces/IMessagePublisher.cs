using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Interfaces
{
    public interface IMessagePublisher
    {
        void Publish<T>(T message);
    }
}
