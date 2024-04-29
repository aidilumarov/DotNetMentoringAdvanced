using CatalogService.Domain.Entities;
using CatalogService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application
{
    public class ItemService
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetAllCategoriesAsync()
        {
            return await _itemRepository.GetAll().ToListAsync();
        }

        public async Task<Item> GetCategoryById(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task AddCategoryAsync(Item item)
        {
            await _itemRepository.AddAsync(item);
        }

        public void UpdateCategory(Item item)
        {
            _itemRepository.Update(item);
        }

        public void DeleteCategory(Item item)
        {
            _itemRepository.Delete(item);
        }
    }
}
