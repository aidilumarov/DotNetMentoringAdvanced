using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using System;

namespace CatalogService.Application.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Image = request.Image,
                ParentCategoryId = request.ParentCategoryId
            };

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            return category.Id;
        }
    }
}
