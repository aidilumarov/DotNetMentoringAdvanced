using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Domain.Interfaces
{
    public interface IMessageListenerFactory
    {
        IMessageListener<T> CreateListener<T>(string queueName, Action<T> messageHandler);
    }
}
