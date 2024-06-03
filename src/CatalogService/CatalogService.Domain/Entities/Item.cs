using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
