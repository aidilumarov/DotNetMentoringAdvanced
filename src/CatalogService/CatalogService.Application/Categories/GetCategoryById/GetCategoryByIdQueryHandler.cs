using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using System;

namespace CatalogService.Application.Categories.GetCategoryById
{
    internal sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse?>
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryToFetch = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryToFetch != null)
            {
                return new CategoryResponse()
                {
                    Id = categoryToFetch.Id,
                    Name = categoryToFetch.Name,
                    Image = categoryToFetch.Image
                };
            }

            return null;
        }
    }
}
