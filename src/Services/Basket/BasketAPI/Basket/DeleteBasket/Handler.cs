namespace BasketAPI.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketCommandResult>;

    public record DeleteBasketCommandResult(bool isSuccess);

    public class Handler(IBasketRepository repo) : ICommandHandler<DeleteBasketCommand, DeleteBasketCommandResult>
    {
        public async Task<DeleteBasketCommandResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {

            await repo.DeleteBasket(command.UserName, cancellationToken);

            return new DeleteBasketCommandResult(true);
        }
    }
}
