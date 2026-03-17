

namespace BasketAPI.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketCommandResult>;

    public record StoreBasketCommandResult(string UserName);

    public class Handler(IBasketRepository repo) : ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
    {
        public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;
            var basket = await repo.StoreBasekt(cart, cancellationToken);
            return new StoreBasketCommandResult(basket.UserName);
        }
    }
}
