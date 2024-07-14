using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.GetItemPropertiesById
{
    public sealed record GetItemPropertiesByIdQuery(Guid Id)
        : IRequest<ItemPropertyResponse>;
}
