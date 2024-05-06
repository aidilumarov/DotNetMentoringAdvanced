using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;

namespace CatalogService.Application.Categories.DeleteCategory
{
    internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;

        public DeleteCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category != null)
            {
                _categoryRepository.Delete(category);
                await _categoryRepository.SaveAsync();
            }
        }
    }
}
