using CatalogService.Application.Categories.GetCategoryById;
using MediatR;

namespace CatalogService.Application.Categories.UpdateCategory
{
    internal sealed record UpdateCategoryCommand(Guid Id, string Name, string Image, Guid? parentCategoryId)
        : IRequest;
}
