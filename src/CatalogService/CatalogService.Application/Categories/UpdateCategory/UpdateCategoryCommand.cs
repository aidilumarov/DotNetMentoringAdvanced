using MediatR;

namespace CatalogService.Application.Categories.UpdateCategory
{
    public sealed record UpdateCategoryCommand(Guid Id, string Name, string Image, Guid? parentCategoryId)
        : IRequest;
}
