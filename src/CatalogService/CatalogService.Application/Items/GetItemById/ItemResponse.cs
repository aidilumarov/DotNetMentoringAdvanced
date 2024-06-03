using CatalogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.GetItemById
{
    internal class ItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
