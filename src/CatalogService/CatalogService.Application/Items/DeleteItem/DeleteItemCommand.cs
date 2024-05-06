using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.DeleteItem
{
    public sealed record DeleteItemCommand(Guid Id)
        : IRequest;
}
