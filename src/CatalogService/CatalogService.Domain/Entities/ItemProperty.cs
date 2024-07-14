using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Entities
{
    public class ItemProperty
    {
        public Guid ItemId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public Item Item { get; set; }
    }
}
