using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;

namespace CatalogService.Application.Categories.UpdateCategory
{
    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryToUpdate != null) 
            {
                _categoryRepository.Update(categoryToUpdate);

                categoryToUpdate.Name = request.Name;
                categoryToUpdate.Image = request.Image;

                await _categoryRepository.SaveAsync();
            }
        }
    }
}
