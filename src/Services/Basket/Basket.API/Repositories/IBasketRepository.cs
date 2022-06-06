using System.Threading.Tasks;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetCart(string userName);
        Task<ShoppingCart> UpdateCart(ShoppingCart shoppingCart);
        Task DeleteCart(string userName);
    }

    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;

        public BasketRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task DeleteCart(string userName)
        {
            await _distributedCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetCart(string userName)
        {
            var basket = await _distributedCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateCart(ShoppingCart shoppingCart)
        {
            var basketString = JsonConvert.SerializeObject(shoppingCart);
            await _distributedCache.SetStringAsync(shoppingCart.UserName, basketString);
            return await GetCart(shoppingCart.UserName);
        }
    }
}
