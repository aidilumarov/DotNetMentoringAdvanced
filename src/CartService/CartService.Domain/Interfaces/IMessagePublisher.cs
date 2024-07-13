﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Domain.Interfaces
{
    public interface IMessagePublisher
    {
        void Publish<T>(T message);
    }
}