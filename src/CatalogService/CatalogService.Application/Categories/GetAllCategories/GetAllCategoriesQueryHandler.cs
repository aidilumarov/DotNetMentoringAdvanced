using CatalogService.Application.Categories.GetCategoryById;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application.Categories.GetAllCategories
{
    internal sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetAllCategoriesQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }   

        public async Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll()
                .Select((category, index) =>
                    new CategoryResponse 
                    { 
                        Id = category.Id, 
                        Name = category.Name, 
                        Image = category.Image 
                    })
                .ToListAsync(cancellationToken);
   
        }
    }
}
