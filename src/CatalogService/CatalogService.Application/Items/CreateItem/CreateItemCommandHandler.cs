using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MediatR;

namespace CatalogService.Application.Items.CreateItem
{
    public sealed class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
    {
        private readonly IRepository<Item> _itemRepository;
        public CreateItemCommandHandler(IRepository<Item> itemRepository) 
        {
            _itemRepository = itemRepository;
        }

        public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var itemToCreate = new Item()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Image = request.Image,
                CategoryId = request.CategoryId,
                Price = request.Price,
                Amount = request.Amount,
            };

            await _itemRepository.AddAsync(itemToCreate);
            await _itemRepository.SaveAsync();

            return itemToCreate.Id;
        }
    }
}
