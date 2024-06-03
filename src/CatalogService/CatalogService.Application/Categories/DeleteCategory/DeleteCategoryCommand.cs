using MediatR;

namespace CatalogService.Application.Categories.DeleteCategory
{
    public sealed record DeleteCategoryCommand(Guid Id)
        : IRequest;
}
