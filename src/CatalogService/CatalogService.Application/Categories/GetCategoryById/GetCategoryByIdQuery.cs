using MediatR;

namespace CatalogService.Application.Categories.GetCategoryById
{
    public sealed record GetCategoryByIdQuery(Guid Id) 
        : IRequest<CategoryResponse>;
}
