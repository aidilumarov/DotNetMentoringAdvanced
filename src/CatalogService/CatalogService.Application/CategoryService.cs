using CatalogService.Domain.Entities;
using CatalogService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAll().ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepository.Delete(category);
        }
    }
}
