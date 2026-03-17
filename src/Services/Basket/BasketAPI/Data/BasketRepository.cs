namespace BasketAPI.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToekn)
        {
            session.Delete<ShoppingCart>(UserName);
            await session.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancellationToekn)
        {
            var basket = await session.LoadAsync<ShoppingCart>(UserName, cancellationToekn);

            return basket is null ? throw new Exception("not found") : basket;
        }

        public async Task<ShoppingCart> StoreBasekt(ShoppingCart basket, CancellationToken cancellationToekn)
        {
            session.Store<ShoppingCart>(basket);
            await session.SaveChangesAsync();
            Console.WriteLine(basket);
            return basket;
        }
    }
}
