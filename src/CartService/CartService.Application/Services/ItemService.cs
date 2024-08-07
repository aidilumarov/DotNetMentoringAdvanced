﻿using CartService.Domain;
using CartService.Domain.Repositories;
using CartService.Domain.Repositories.Interfaces;

namespace CartService.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<Item> GetItems(Guid cartId)
        {
            return _itemRepository.GetItems(cartId);
        }

        public void AddItem(Guid cartId, Item item)
        {
            _itemRepository.AddItem(cartId, item);
        }

        public void RemoveItem(Guid cartId, Guid itemId)
        {
            _itemRepository.RemoveItem(cartId, itemId);
        }
    }
}
