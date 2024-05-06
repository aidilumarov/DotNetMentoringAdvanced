using System;
using System.Collections.ObjectModel;

namespace CatalogService.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public Collection<Category> Subcategories { get; }
        public Collection<Item> Items { get; }
    }
}
