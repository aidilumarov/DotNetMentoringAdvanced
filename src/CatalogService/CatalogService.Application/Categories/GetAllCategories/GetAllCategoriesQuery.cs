using CatalogService.Application.Categories.GetCategoryById;
using MediatR;

namespace CatalogService.Application.Categories.GetAllCategories
{
    public sealed record GetAllCategoriesQuery() 
        : IRequest<List<CategoryResponse>>;
}
