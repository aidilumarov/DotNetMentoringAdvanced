using CatalogService.Domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace CatalogService.Application.Categories.CreateCategory
{
    public sealed record CreateCategoryCommand(string Name, string Image, Guid? ParentCategoryId)
        : IRequest<Guid>;
}
