using CatalogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Categories.GetCategoryById
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
