namespace BasketAPI.Data
{
    public interface IBasketRepository
    {
        public Task<ShoppingCart> GetBasket(string UserName, CancellationToken token);
        public Task<ShoppingCart> StoreBasekt(ShoppingCart Cart, CancellationToken token);
        public Task<bool> DeleteBasket(string UserName, CancellationToken token);

    }
}
