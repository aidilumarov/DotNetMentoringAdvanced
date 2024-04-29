using CartService.Domain;
using CartService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application
{
    internal class CartService
    {
        private readonly CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCart(int id)
        {
            return _cartRepository.GetCart(id);
        }

        public Cart AddCart(Cart cart)
        {
            return _cartRepository.AddCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        }

        public void DeleteCart(int id)
        {
            _cartRepository.DeleteCart(id);
        }
    }
}
